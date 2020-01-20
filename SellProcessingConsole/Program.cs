namespace SellProcessingConsole
{
    using System;

    using System.Threading;

    using BussinessLayer;

    class Program
    {
        static ISellProvider sellProvider;

        static void Main(string[] args)
        {
            sellProvider = new SellProvider(true);
            sellProvider.StartedFileProcessingEvent += SellProvider_FileProcessingEvent;
            sellProvider.FinishedFileProcessingEvent += SellProvider_FileProcessingEvent;
            try
            {
                sellProvider.StartFilesProcessing();
                Thread.Sleep(10000);
                sellProvider.StopFilesProcessing();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sellProvider.Dispose();
            }
        }

        private static void SellProvider_FileProcessingEvent(string message)
        {
            Console.WriteLine(message);
        }
    }
}
