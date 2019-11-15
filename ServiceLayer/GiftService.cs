using System;
using System.Collections.Generic;
using DataLayer;
using DataLayer.Sweets;
using DataLayer.Sweets.Components;

namespace ServiceLayer
{
    public class GiftService
    {
        private NewYearGift newYearGift;

        public GiftService()
        {
            this.newYearGift = new NewYearGift();
        }

        public bool CreateNewItem(string type, Dictionary<string,object> parameters)
        {
            switch(type)
            {
                case "cake": {
                        if (!GiftItemValidator.CakeValidate(parameters))
                            return false;
                        IGiftItem cake = new Cake(
                            (int)parameters["id"],
                            (string)parameters["name"],
                            (string)parameters["producer"],
                            (CakeType)parameters["cakeType"]);
                        this.newYearGift.AddNewItem(cake);
                        return true;
                    }
                default:return false;
            }
        }

        private Sweets AddAdditionalComponents(Sweets sweets, Dictionary<string, object> parameters)
        {
            Sweets sweetsWithComponents = sweets;
            if (parameters.ContainsKey("berryAmount")
                && parameters.ContainsKey("berryName")
                && parameters.ContainsKey("berryMadeOf"))
                sweetsWithComponents = new Berries(sweets,
                    (int)parameters["berryAmount"],
                    (string)parameters["berryName"],
                    (string)parameters["berryMadeOf"]);
            return sweetsWithComponents;
        }

        public double GetGiftWeight()
        {
            double weight = 0.0;
            IList<IGiftItem> giftItems = this.newYearGift.GetAllItems();
            foreach (IGiftItem giftItem in giftItems)
                weight += giftItem.Weight;
            return weight;
        }

        public IList<Sweets> FindCandyBySugar(double min, double max)
        {
            IList<Sweets> foundSweets = new List<Sweets>();
            IList<Sweets> sweets = this.newYearGift.GetSweets();
            foreach (Sweets giftItem in sweets)
                if (giftItem.Sugar >= min && giftItem.Sugar <= max)
                    foundSweets.Add(giftItem);
            return foundSweets;
        }

        public IList<IGiftItem> SortByWeight()
        {
            IList<IGiftItem> giftItems = this.newYearGift.GetAllItems();
            ((List<IGiftItem>)giftItems).Sort((a, b) => a.Weight.CompareTo(b.Weight));
            return giftItems;
        }

        public IList<IGiftItem> GetGiftItems()
        {
            return this.newYearGift.GetAllItems();
        }
    }
}
