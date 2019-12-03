namespace DataLayer
{
    using System.Collections.Generic;

    public interface IParagraph : ITextComponent
    {
        ICollection<ISentence> SentencesCollection { get; }

        bool AddSentence(ISentence paragraph);

        bool DeleteSentence(ISentence paragraph);

        void SetLineBreak();
    }
}