namespace BussinessLayer
{
    using System;

    using System.Configuration;

    using System.IO;

    using System.Collections.Generic;

    using System.Threading.Tasks;

    using SellParser;

    using BussinessObjects;

    using DataLayer;

    using DataLayer.DbContexts;

    using DataLayer.Entities;

    using DataLayer.Entities.Enums;

    using ObjectMapper;

    using System.Threading;

    public delegate void FileProcessingStateHandler(string message);

    public class SellProvider : ISellProvider
    {
        string directoryPath;

        string directoryForReadFiles;

        bool isConsole;

        DataProvider dataProvider;

        ObjectMapper.ObjectMapper objectMapper;

        static string started = " is started processing.";

        static string finished = "is finished processing.";

        static string cancelled = "Process was cancelled.";

        CancellationTokenSource cancelTokenSource;

        CancellationToken token;

        FileSystemWatcher watcher;

        public SellProvider(bool isConsole)
        {
            directoryPath = ConfigurationManager.AppSettings.Get("ObservingDirectoryPath");
            directoryForReadFiles = $"{directoryPath}\\ReadFiles";
            this.isConsole = isConsole;
            dataProvider = new DataProvider(new SellDbContext());
            objectMapper = new ObjectMapper.ObjectMapper();

            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            watcher = new FileSystemWatcher();
        }

        public SellProvider(string directoryPath, bool isConsole)
        {
            this.directoryPath = directoryPath;
            directoryForReadFiles = $"{directoryPath}\\ReadFiles";
            this.isConsole = isConsole;
            dataProvider = new DataProvider(new SellDbContext());
            objectMapper = new ObjectMapper.ObjectMapper();

            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            watcher = new FileSystemWatcher();
        }

        public event FileProcessingStateHandler StartedFileProcessingEvent;

        public event FileProcessingStateHandler FinishedFileProcessingEvent;

        public void StartFilesProcessing()
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException();
            }
            else
            {
                Directory.CreateDirectory(directoryForReadFiles);
                var fileNames = Directory.GetFiles(directoryPath);
                while (fileNames.Length != 0)
                {
                    try
                    {
                        Parallel.ForEach<string>(fileNames,
                                    new ParallelOptions { CancellationToken = token }, ProcessFile);
                    }
                    catch(OperationCanceledException ex)
                    {
                        throw ex;
                    }
                    fileNames = Directory.GetFiles(directoryPath);
                }

                watcher.Path = directoryPath;
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
                watcher.Filter = "*.csv";
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
            }
        }

        public void StopFilesProcessing()
        {
            cancelTokenSource.Cancel();
            watcher.EnableRaisingEvents = false;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Deleted)
            {
                var fileNames = Directory.GetFiles(directoryPath);
                try
                {
                    Parallel.ForEach<string>(fileNames,
                                new ParallelOptions { CancellationToken = token }, ProcessFile);
                }
                catch (OperationCanceledException ex)
                {
                    throw ex;
                }
            }
        }

        private void ProcessFile(string fileName)
        {
            string fullFilePath = $"{directoryPath}\\{fileName}";
            if (File.Exists(fullFilePath))
            {
                FileWithSellings file = SellParser.SellParser.ParseFileName(fileName);
                var fileHashEntity = dataProvider.FindFileHash(file.GetHashCode());
                bool fileNotExists = (fileHashEntity == null);
                if (fileNotExists
                    || (fileHashEntity.ProcessingState == FileProcessingState.ProcessingByConsoleApp && isConsole)
                    || (fileHashEntity.ProcessingState == FileProcessingState.ProcessingByService && !isConsole))
                {
                    if (fileNotExists)
                    {
                        AddNewFile(file);
                    }
                    OnStartedFileProcessing(fileName);
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        var sellings = SellParser.SellParser.Parse(fileStream);
                        foreach (var selling in sellings)
                        {
                            bool sellingExists = false;
                            if (!fileNotExists)
                            {
                                sellingExists = dataProvider.ExistsSelling(selling.GetHashCode());
                            }
                            if (!sellingExists)
                            {
                                var sellingEntity = objectMapper.ToDataObject(selling);
                                var sellingHashEntity = objectMapper.ToHashDataObject(selling, sellingEntity);
                                dataProvider.AddSelling(sellingEntity, sellingHashEntity);
                            }
                        }
                    }
                    dataProvider.UpdateFileState(file.GetHashCode());
                    Directory.Move(fullFilePath, $"{directoryForReadFiles}\\{fileName}");
                    OnFinishedFileProcessing(fileName);
                }
            }
        }

        private void AddNewFile(FileWithSellings file)
        {
            var fileEntity = objectMapper.ToDataObject(file);
            var fileHashEntity = objectMapper.ToHashDataObject(file, fileEntity);
            if (isConsole)
            {
                fileHashEntity.ProcessingState = FileProcessingState.ProcessingByConsoleApp;
            }
            else
            {
                fileHashEntity.ProcessingState = FileProcessingState.ProcessingByService;
            }
            dataProvider.AddFile(fileEntity, fileHashEntity);
        }

        protected virtual void OnStartedFileProcessing(string fileName)
        {
            string message = $"{fileName}{SellProvider.started}";
            StartedFileProcessingEvent?.Invoke(message);
        }

        protected virtual void OnFinishedFileProcessing(string fileName)
        {
            string message = $"{fileName}{SellProvider.finished}";
            FinishedFileProcessingEvent?.Invoke(message);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dataProvider.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                cancelTokenSource.Dispose();
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~SellProvider()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
