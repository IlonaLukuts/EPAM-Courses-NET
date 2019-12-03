namespace DataLayer
{
    using System;
    using System.Collections.Generic;

    public interface IWord : ISentenceItem, IEquatable<IWord>
    {
        bool HasDash { get; }

        ICollection<ILetter> LettersCollection { get; }

        bool AddLetter(ILetter letter);

        bool DeleteLetter(ILetter letter);

        void SetLineBreak();

        void SetDash();
    }
}