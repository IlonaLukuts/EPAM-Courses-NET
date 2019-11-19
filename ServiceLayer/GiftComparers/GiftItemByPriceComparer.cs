
namespace ServiceLayer.GiftComparers
{
    using System.Collections.Generic;

    using DataLayer;

    public class GiftItemByPriceComparer : IComparer<IGiftItem>
    {
        public int Compare(IGiftItem giftItem1, IGiftItem giftItem2)
        {
            return giftItem1.Price.CompareTo(giftItem2.Price);
        }
    }
}