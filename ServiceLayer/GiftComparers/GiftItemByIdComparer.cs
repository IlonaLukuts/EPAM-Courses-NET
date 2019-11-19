
namespace ServiceLayer.GiftComparers
{
    using System.Collections.Generic;

    using DataLayer;

    public class GiftItemByIdComparer : IComparer<IGiftItem>
    {
        public int Compare(IGiftItem giftItem1, IGiftItem giftItem2)
        {
            return giftItem1.Id.CompareTo(giftItem2.Id);
        }
    }
}