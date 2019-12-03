namespace DataLayer.Impl
{
    using System.Globalization;
    using System.Linq;

    public class PunctuationLeaf : TextComponent, IPunctuation
    {
        private static char[] notRequireSpaces = new[] { '.', '?', '!', '@' };

        private static char[] requireSpacesBeforeChars = new[] { '#' };

        private static char[] requireSpacesAfterChars = new[] { ',', '%', ':', ';' };

        private static char[] requireBothSpacesChars = new[] { '*', '/', '\\' };

        public string Signs { get; private set; }

        public int SentencePosition { get; set; }
        
        public void AddSign(char sign)
        {
            this.Signs += sign;
        }

        public override string ToString()
        {
            return this.Signs;
        }

        public void RequireSpaces(out bool spaceBefore, out bool spaceAfter)
        {
            char lastSign = this.Signs[this.Signs.Length - 1];
            UnicodeCategory unicodeCategory = char.GetUnicodeCategory(lastSign);
            switch (unicodeCategory)
            {
                case UnicodeCategory.OpenPunctuation:
                    {
                        spaceBefore = true;
                        spaceAfter = false;
                        break;
                    }
                case UnicodeCategory.ClosePunctuation:
                case UnicodeCategory.CurrencySymbol:
                    {
                        spaceBefore = false;
                        spaceAfter = true;
                        break;
                    }
                case UnicodeCategory.MathSymbol:
                case UnicodeCategory.DashPunctuation:
                    {
                        spaceBefore = true;
                        spaceAfter = true;
                        break;
                    }
                default:
                    {
                        if (notRequireSpaces.Contains(lastSign))
                        {
                            spaceAfter = false;
                            spaceBefore = false;
                        }
                        else
                        {
                            if (requireSpacesBeforeChars.Contains(lastSign))
                            {
                                spaceBefore = true;
                                spaceAfter = false;
                            }
                            else
                            {
                                if (requireSpacesAfterChars.Contains(lastSign))
                                {
                                    spaceBefore = false;
                                    spaceAfter = true;
                                }
                                else
                                {
                                    spaceBefore = true;
                                    spaceAfter = true;
                                }
                            }
                        }

                        break;
                    }
            }
        }
    }
}