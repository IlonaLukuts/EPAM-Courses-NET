namespace ServiceLayer
{
    using System.Collections.Generic;
    using System.IO;

    using DataLayer;

    public interface ITextProcessingService
    {
        IText GetText();

        bool ParseText(Stream stream);

        IEnumerable<ISentence> AllSentencesOrderedByWordsAmount();

        ICollection<IEnumerable<ISentenceItem>> WordsInInterrogativeSentences(int length);

        IText TextWithoutWordsStartWithConsonantLetters();

        void ReplaceWordInSentence(ISentence sentence, int wordLength, string stringForReplace);

        ISentence FindSentence(int id);
    }
}