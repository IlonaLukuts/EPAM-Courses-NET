namespace BussinessLayer
{
    using System;

    using System.Collections.Generic;

    using BussinessObjects;

    using BussinessObjects.Enums;

    using DataLayer;

    using DataLayer.DbContexts;

    using DataLayer.Entities;

    public delegate void FileProcessingStateHandler(string message);

    public class WebSellProvider : IWebSellProvider
    {
        WebUnitOfWork webUnitOfWork;

        ObjectMapper.ObjectMapper objectMapper;

        public WebSellProvider()
        {
            webUnitOfWork = new WebUnitOfWork(new SellDbContext());
            objectMapper = new ObjectMapper.ObjectMapper();
        }

        public bool CheckUserAndPassword(string login, string password, out bool isAdmin)
        {
            var user = objectMapper.ToBusinessObject(
            webUnitOfWork.FindUser(login));
            if (user!=null)
            {
                isAdmin = (user.UserRole == UserRole.Administrator);
                return user.Password == password;
            }
            else
            {
                isAdmin = false;
                return false;
            }
        }

        public ICollection<Selling> GetSellings()
        {
            var sellingEntities = webUnitOfWork.GetAllSellings();
            ICollection<Selling> sellings = new List<Selling>();
            foreach(var sellingEntity in sellingEntities)
            {
                sellings.Add(objectMapper.ToBusinessObject(sellingEntity));
            }
            return sellings;
        }

        public void UpdateSelling(Selling updatedSelling)
        {
            webUnitOfWork.UpdateSelling(objectMapper.ToDataObject(updatedSelling));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    webUnitOfWork.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~WebSellProvider()
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
