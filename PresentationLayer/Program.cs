using System;
using ServiceLayer;
using DataLayer;
using DataLayer.Sweets;
using System.Collections.Generic;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            GiftService giftItemService = new GiftService();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", 1);
            parameters.Add("name", "Cheesecake");
            parameters.Add("producer", "Company");
            parameters.Add("cakeType", CakeType.Biscuit);
            giftItemService.CreateNewItem("cake", parameters);
            IList<IGiftItem> giftItems = giftItemService.GetGiftItems();
            foreach (IGiftItem giftItem in giftItems)
                Console.WriteLine(giftItem.ToString());
            Console.WriteLine("Weight: " + giftItemService.GetGiftWeight());
        }
    }
}
