namespace DataLayer
{
    using System.Collections.Generic;

    public interface ISentence : ITextComponent
    {
        ICollection<ISentenceItem> SentenceItemsCollection { get; }

        bool AddSentenceItem(ISentenceItem sentenceItem);

        bool DeleteSentenceItem(ISentenceItem sentenceItem);

        void SetLineBreak();
    }
}