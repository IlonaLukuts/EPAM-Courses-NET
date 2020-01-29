namespace DataLayer
{
    using System;

    using System.Collections.Generic;

    using System.Data.Entity;

    using Entities;

    using GenericRepository;

    public class WebUnitOfWork : IDisposable
    {
        DbContext dbContext;

        IGenericRepository<SellingEntity> sellingRepository;

        IGenericRepository<UserEntity> userRepository;

        public WebUnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
            sellingRepository = new GenericRepository<SellingEntity>(this.dbContext);
            userRepository = new GenericRepository<UserEntity>(this.dbContext);

        }

        public UserEntity FindUser(string login)
        {
            return userRepository.FirstOrDefault(x => x.Login == login);
        }

        public IEnumerable<SellingEntity> GetAllSellings()
        {
            return sellingRepository.Get();
        }

        public void UpdateSelling(SellingEntity updatedSelling)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var selling = sellingRepository.FirstOrDefault(x => x.Id == updatedSelling.Id);
                    selling = updatedSelling;
                    dbContext.SaveChanges();
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
        ~WebUnitOfWork()
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
