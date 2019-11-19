
namespace ServiceLayer.GiftComparers
{
    using System.Collections.Generic;

    using DataLayer;

    public class GiftItemByNameComparer : IComparer<IGiftItem>
    {
        public int Compare(IGiftItem giftItem1, IGiftItem giftItem2)
        {
            return giftItem1.Name.CompareTo(giftItem2.Name);
        }
    }
}