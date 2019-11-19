
namespace ServiceLayer
{
    using System.Collections.Generic;
    using System.Linq;

    using DataLayer;
    using DataLayer.Sweets;
    using DataLayer.Sweets.Components;
    using DataLayer.Sweets.Components.Enums;
    using DataLayer.Sweets.Enums;

    public class GiftService
    {
        private static string idField = "id";

        private static string nameField = "name";

        private static string producerField = "producer";

        private static string cakeTypeField = "cakeType";

        private static string candyTypeField = "candyType";

        private static string cookieTypeField = "cookieType";

        private static string marmaladeTasteField = "marmaladeTaste";

        private static string marshmallowTypeField = "marshmallowType";

        private static string marshmallowTasteField = "marshmallowTaste";

        private static string berryAmountField = "berryAmount";

        private static string berryNameField = "berryName";

        private static string berryMadeOfField = "berryMadeOf";

        private static string fillingNameField = "fillingName";

        private static string glazeNameField = "glazeName";

        private static string nutsNameField = "nutsName";

        private static string nutsIsCrushedField = "nutsIsCrushed";

        private static string predictionTextField = "predictionText";

        private static string toppingShapeField = "toppingShape";

        private static string toppingColorField = "toppingColor";
        
        private NewYearGift newYearGift;

        public GiftService()
        {
            this.newYearGift = new NewYearGift();
        }

        public bool CreateNewItem(string type, Dictionary<string,object> parameters)
        {
            switch (type)
            {
                case "cake":
                    {
                        if (!GiftItemValidator.CakeValidate(parameters))
                            return false;
                        IGiftItem cake = new Cake(
                            (int)parameters[idField],
                            (string)parameters[nameField],
                            (string)parameters[producerField],
                            (CakeType)parameters[cakeTypeField]);
                        cake = this.AddAdditionalComponents((Sweets)cake, parameters);
                        this.newYearGift.AddNewItem(cake);
                        return true;
                    }

                case "candy":
                    {
                        if (!GiftItemValidator.CandyValidate(parameters))
                            return false;
                        IGiftItem candy = new Candy(
                            (int)parameters[idField],
                            (string)parameters[nameField],
                            (string)parameters[producerField],
                            (CandyType)parameters[candyTypeField]);
                        candy = this.AddAdditionalComponents((Sweets)candy, parameters);
                        this.newYearGift.AddNewItem(candy);
                        return true;
                    }

                case "candyBar":
                    {
                        if (!GiftItemValidator.CandyBarValidate(parameters))
                            return false;
                        IGiftItem candyBar = new CandyBar(
                            (int)parameters[idField],
                            (string)parameters[nameField],
                            (string)parameters[producerField]);
                        candyBar = this.AddAdditionalComponents((Sweets)candyBar, parameters);
                        this.newYearGift.AddNewItem(candyBar);
                        return true;
                    }

                case "cookie":
                    {
                        if (!GiftItemValidator.CookieValidate(parameters))
                            return false;
                        IGiftItem cookie = new Cookie(
                            (int)parameters[idField],
                            (string)parameters[nameField],
                            (string)parameters[producerField],
                            (CookieType)parameters[cookieTypeField]);
                        cookie = this.AddAdditionalComponents((Sweets)cookie, parameters);
                        this.newYearGift.AddNewItem(cookie);
                        return true;
                    }

                case "marmalade":
                    {
                        if (!GiftItemValidator.MarmaladeValidate(parameters))
                            return false;
                        IGiftItem marmalade = new Marmalade(
                            (int)parameters[idField],
                            (string)parameters[nameField],
                            (string)parameters[producerField],
                            (string)parameters[marmaladeTasteField]);
                        marmalade = this.AddAdditionalComponents((Sweets)marmalade, parameters);
                        this.newYearGift.AddNewItem(marmalade);
                        return true;
                    }

                case "marshmallow":
                    {
                        if (!GiftItemValidator.MarmaladeValidate(parameters))
                            return false;
                        IGiftItem marshmallow = new Marshmallow(
                            (int)parameters[idField],
                            (string)parameters[nameField],
                            (string)parameters[producerField],
                            (MarshmallowType)parameters[marshmallowTypeField],
                            (string)parameters[marshmallowTasteField]);
                        marshmallow = this.AddAdditionalComponents((Sweets)marshmallow, parameters);
                        this.newYearGift.AddNewItem(marshmallow);
                        return true;
                    }

                default: return false;
            }
        }

        public double GetGiftWeight()
        {
            IList<IGiftItem> giftItems = this.newYearGift.GetAllItems();
            var weight = (from g in giftItems select g.Weight).Sum();
            return weight;
        }

        public IEnumerable<Sweets> FindCandyBySugar(double min, double max)
        {
            IList<Sweets> sweets = this.newYearGift.GetSweets();
            var foundSweets = from s in sweets where s.Sugar >= min && s.Sugar <= max select s;
            return foundSweets;
        }

        public IList<IGiftItem> Sort(IComparer<IGiftItem> giftComparer)
        {
            IList<IGiftItem> giftItems = this.newYearGift.GetAllItems();
            ((List<IGiftItem>)giftItems).Sort(giftComparer);
            return giftItems;
        }

        public IList<IGiftItem> GetGiftItems()
        {
            return this.newYearGift.GetAllItems();
        }

        private Sweets AddAdditionalComponents(Sweets sweets, Dictionary<string, object> parameters)
        {
            Sweets sweetsWithComponents = sweets;
            if (parameters.ContainsKey(berryAmountField) && parameters.ContainsKey(berryNameField)
                                                         && parameters.ContainsKey(berryMadeOfField))
            {
                sweetsWithComponents = new Berries(
                    sweets,
                    (int)parameters[berryAmountField],
                    (string)parameters[berryNameField],
                    (string)parameters[berryMadeOfField]);
            }

            if (parameters.ContainsKey(fillingNameField))
            {
                sweetsWithComponents = new Filling(
                    sweets,
                    (string)parameters[fillingNameField]);
            }

            if (parameters.ContainsKey(glazeNameField))
            {
                sweetsWithComponents = new Glaze(
                    sweets,
                    (string)parameters[glazeNameField]);
            }

            if (parameters.ContainsKey(nutsNameField) && parameters.ContainsKey(nutsIsCrushedField))
            {
                sweetsWithComponents = new Nuts(
                    sweets,
                    (string)parameters[nutsNameField],
                    (bool)parameters[nutsIsCrushedField]);
            }

            if (parameters.ContainsKey(predictionTextField))
            {
                sweetsWithComponents = new Prediction(
                    sweets,
                    (string)parameters[predictionTextField]);
            }

            if (parameters.ContainsKey(toppingShapeField) && parameters.ContainsKey(toppingColorField))
            {
                sweetsWithComponents = new Topping(
                    sweets,
                    (ToppingShape)parameters[toppingShapeField],
                    (string)parameters[toppingColorField]);
            }

            return sweetsWithComponents;
        }
    }
}
