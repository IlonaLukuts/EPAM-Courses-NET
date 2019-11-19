namespace ServiceLayer.GiftComparers
{
    using System.Collections.Generic;

    using DataLayer;

    public class GiftItemByWeightComparer : IComparer<IGiftItem>
    {
        public int Compare(IGiftItem giftItem1, IGiftItem giftItem2)
        {
            return giftItem1.Weight.CompareTo(giftItem2.Weight);
        }
    }
}