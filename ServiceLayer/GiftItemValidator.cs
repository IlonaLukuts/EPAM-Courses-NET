
namespace ServiceLayer
{
    using System.Collections.Generic;

    class GiftItemValidator
    {
        public static bool MarshmallowValidate(Dictionary<string, object> parameters)
        {
            if (!GiftItemValidate(parameters))
                return false;
            return true;
        }

        public static bool CandyValidate(Dictionary<string, object> parameters)
        {
            if (!GiftItemValidate(parameters))
                return false;
            return true;
        }
        public static bool CookieValidate(Dictionary<string, object> parameters)
        {
            if (!GiftItemValidate(parameters))
                return false;
            return true;
        }

        public static bool CandyBarValidate(Dictionary<string, object> parameters)
        {
            if (!GiftItemValidate(parameters))
                return false;
            return true;
        }

        public static bool MarmaladeValidate(Dictionary<string, object> parameters)
        {
            if (!GiftItemValidate(parameters))
                return false;
            return true;
        }

        public static bool CakeValidate(Dictionary<string, object> parameters)
        {
            if (!GiftItemValidate(parameters))
                return false;
            return true;
        }
        
        private static bool GiftItemValidate(Dictionary<string, object> parameters)
        {
            if (!(parameters.ContainsKey("name") &&
                  parameters.ContainsKey("producer")))
                return false;
            return true;
        }
    }
}
