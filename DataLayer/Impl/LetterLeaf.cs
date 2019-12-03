namespace DataLayer.Impl
{
    public class LetterLeaf : TextComponent, ILetter
    {
        public LetterLeaf(char letter)
        {
            this.Letter = letter;
        }

        public char Letter { get; }

        public override string ToString()
        {
            return this.Letter.ToString();
        }
    }
}