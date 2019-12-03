namespace ServiceLayer.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;

    using DataLayer;

    public class TextProcessingService : ITextProcessingService
    {
        private static char[] consonantChars = new[]
                                                   {
                                                       'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q',
                                                       'R', 'S', 'T', 'V', 'X', 'Z', 'W', 'Y'
                                                   };

        private IText text;

        private IParser parser;

        public TextProcessingService()
        {
            this.parser = new Parser();
        }

        public IText GetText()
        {
            return this.text;
        }

        public bool ParseText(Stream stream)
        {
            this.text = this.parser.Parse(stream);
            if (this.text == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<ISentence> AllSentencesOrderedByWordsAmount()
        {
            return from paragraph in this.text.ParagraphsCollection
                   from sentence in paragraph.SentencesCollection
                   orderby this.GetWords(sentence).Count()
                   select sentence;
        }
        
        public ICollection<IEnumerable<ISentenceItem>> WordsInInterrogativeSentences(int length)
        {
            var interrogativeSentences = from paragraph in this.text.ParagraphsCollection
                                         from sentence in paragraph.SentencesCollection
                                         where IsSentenceInterrogative(sentence)
                                         select sentence;
            ICollection<IEnumerable<ISentenceItem>> resultCollection = new Collection<IEnumerable<ISentenceItem>>();
            foreach (var interrogativeSentence in interrogativeSentences)
            {
                IEnumerable<ISentenceItem> words = GetWords(interrogativeSentence);
                var wordsWithRequireLength = from sentenceItem in words
                                             where ((IWord)sentenceItem).LettersCollection.Count == length
                                             select sentenceItem;
                resultCollection.Add(wordsWithRequireLength.Distinct());
            }

            return resultCollection;
        }

        public IText TextWithoutWordsStartWithConsonantLetters()
        {
            var wordsForDeleting = from paragraph in this.text.ParagraphsCollection
                                   from sentence in paragraph.SentencesCollection
                                   from word in this.GetWords(sentence)
                                   where this.IsFirstLetterConsonant((IWord)word)
                                   select new { Sentence = sentence, Word = word };
            foreach (var item in wordsForDeleting)
            {
                item.Sentence.DeleteSentenceItem(item.Word);
            }

            return this.text;
        }

        public void ReplaceWordInSentence(ISentence sentence, int wordLength, string stringForReplace)
        {
            StringBuilder stringBuilder = new StringBuilder(sentence.ToString());
            var wordsForReplacing = from word in this.GetWords(sentence)
                                    where ((IWord)word).LettersCollection.Count == wordLength
                                    select word;
            foreach (var word in wordsForReplacing)
            {
                stringBuilder.Replace(word.ToString(), stringForReplace);
            }

            ISentence newSentence = this.parser.ReparseSentence(sentence.Id, sentence.StartLinePosition, stringBuilder.ToString());
            IParagraph paragraph = this.text.ParagraphsCollection.First(x => x.SentencesCollection.Contains(sentence));
            paragraph.DeleteSentence(sentence);
            paragraph.AddSentence(newSentence);
        }

        private bool IsFirstLetterConsonant(IWord word)
        {
            char firstLetter = (word.LettersCollection.ToList())[0].Letter;
            return consonantChars.Contains(char.ToUpper(firstLetter));
        }

        private bool IsSentenceInterrogative(ISentence sentence)
        {
            ISentenceItem punctuation = (from sentenceItem in sentence.SentenceItemsCollection
                                          orderby sentenceItem.Id
                                          select sentenceItem).Last();
            try
            {
                IPunctuation endPunctuation = punctuation as IPunctuation;
                if (endPunctuation.Signs[endPunctuation.Signs.Length - 1].Equals('?'))
                {
                    return true;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }

            return false;
        }

        private IEnumerable<ISentenceItem> GetWords(ISentence sentence)
        {
            Type type = Type.GetType("IWord");
            return (from sentenceItem in sentence.SentenceItemsCollection
                    where sentenceItem.GetType() == type
                    select sentenceItem);
        }
    }
}
