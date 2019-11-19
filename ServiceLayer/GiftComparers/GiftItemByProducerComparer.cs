
namespace ServiceLayer.GiftComparers
{
    using System.Collections.Generic;

    using DataLayer;

    public class GiftItemByProducerComparer : IComparer<IGiftItem>
    {
        public int Compare(IGiftItem giftItem1, IGiftItem giftItem2)
        {
            return giftItem1.Producer.CompareTo(giftItem2.Producer);
        }
    }
}