namespace DataLayer
{
    using System;

    using System.Collections.Generic;

    using System.Data.Entity;

    using Entities;

    using GenericRepository;

    public class DataProvider : IDisposable
    {
        DbContext dbContext;

        IGenericRepository<FileEntity> fileRepository;

        IGenericRepository<FileHashEntity> fileHashRepository;

        IGenericRepository<ManagerEntity> managerRepository;

        IGenericRepository<SellingEntity> sellingRepository;
        
        IGenericRepository<SellingHashEntity> sellingHashRepository;

        public DataProvider(DbContext dbContext)
        {
            this.dbContext = dbContext;
            fileRepository = new GenericRepository<FileEntity>(this.dbContext);
            fileHashRepository = new GenericRepository<FileHashEntity>(this.dbContext);
            managerRepository = new GenericRepository<ManagerEntity>(this.dbContext);
            sellingRepository = new GenericRepository<SellingEntity>(this.dbContext);
            sellingHashRepository = new GenericRepository<SellingHashEntity>(this.dbContext);

        }

        public void AddSelling(SellingEntity selling, SellingHashEntity sellingHash)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (ExistsSelling(sellingHash))
                        transaction.Rollback();
                    else
                    {
                        sellingRepository.Create(selling);
                        sellingHashRepository.Create(sellingHash);
                        dbContext.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void AddFile(FileEntity file, FileHashEntity fileHash)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (ExistsFile(fileHash))
                        transaction.Rollback();
                    else
                    {
                        fileRepository.Create(file);
                        fileHashRepository.Create(fileHash);
                        dbContext.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public bool ExistsSelling(int sellingHash)
        {
            var sellingHashEntity = sellingHashRepository.FirstOrDefault(x => x.Hash == sellingHash);
            return sellingHashEntity != null;
        }

        public FileHashEntity FindFileHash(int fileHash)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var fileHashEntity = fileHashRepository.FirstOrDefault(x => x.Hash == fileHash);
                    transaction.Commit();
                    return fileHashEntity;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void UpdateFileState(int hash)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var fileHashEntity = fileHashRepository.FirstOrDefault(x => x.Hash == hash);
                    fileHashEntity.ProcessingState = Entities.Enums.FileProcessingState.Finished;
                    fileHashRepository.Update(fileHashEntity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    // TODO: dispose managed state (managed objects).
                }

                dbContext.Dispose();
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~DataProvider()
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
