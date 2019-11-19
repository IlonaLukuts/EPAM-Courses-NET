
namespace DataLayer
{
    using System.Collections.Generic;

    public class NewYearGift
    {
        private IList<IGiftItem> giftItems;

        public NewYearGift()
        {
            this.giftItems = new List<IGiftItem>();
        }

        public IList<IGiftItem> GetAllItems()
        {
            IList<IGiftItem> giftItems = new List<IGiftItem>(this.giftItems);
            return giftItems;
        }

        public IList<Sweets.Sweets> GetSweets()
        {
            IList<Sweets.Sweets> sweets = new List<Sweets.Sweets>();
            foreach (IGiftItem giftItem in this.giftItems)
            {
                if (giftItem is Sweets.Sweets)
                    sweets.Add((Sweets.Sweets)giftItem);
            }
            return sweets;
        }
    

        public void AddNewItem(IGiftItem giftItem)
        {
            this.giftItems.Add(giftItem);
        }

        public void DeleteItem(IGiftItem giftItem)
        {
            this.giftItems.Remove(giftItem);
        }
    }
}
