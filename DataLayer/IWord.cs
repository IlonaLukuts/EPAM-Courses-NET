namespace DataLayer
{
    using System.Collections.Generic;

    public interface IWord : ISentenceItem
    {
        bool HasDash { get; }

        ICollection<ILetter> LettersCollection { get; }

        bool AddLetter(ILetter letter);

        bool DeleteLetter(ILetter letter);

        void SetLineBreak();

        void SetDash();
    }
}