namespace DataLayer
{
    public interface IPunctuation : ISentenceItem
    {
        string Signs { get; }

        void AddSign(char sign);

        void RequireSpaces(out bool spaceBefore, out bool spaceAfter);
    }
}