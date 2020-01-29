namespace BussinessLayer
{
    using System;

    using System.Collections.Generic;

    using BussinessObjects;

    public interface IWebSellProvider : IDisposable
    {
        bool CheckUserAndPassword(string login, string password, out bool isAdmin);

        ICollection<Selling> GetSellings();

        void UpdateSelling(Selling updatedSelling);
    }
}
