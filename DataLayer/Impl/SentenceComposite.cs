namespace DataLayer.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class SentenceComposite : TextComponent, IEquatable<SentenceComposite>, ISentence
    {
        private bool isThereLineBreak;

        public SentenceComposite()
        {
            this.SentenceItemsCollection = new Collection<ISentenceItem>();
            this.isThereLineBreak = false;
        }

        public ICollection<ISentenceItem> SentenceItemsCollection { get; }


        public bool AddSentenceItem(ISentenceItem sentenceItem)
        {
            this.SentenceItemsCollection.Add(sentenceItem);
            return true;
        }

        public bool DeleteSentenceItem(ISentenceItem sentenceItem)
        {
            this.SentenceItemsCollection.Remove(sentenceItem);
            return true;
        }

        public void SetLineBreak()
        {
            this.isThereLineBreak = true;
        }
        
        public bool Equals(SentenceComposite other)
        {
            return base.Equals(other)
                   && (from sentenceItem in this.SentenceItemsCollection select sentenceItem).All(other.SentenceItemsCollection.Contains)
                   && this.SentenceItemsCollection.Count.Equals(other.SentenceItemsCollection.Count)
                   && this.isThereLineBreak.Equals(other.isThereLineBreak);
        }

        public override string ToString()
        {
            Type type = Type.GetType("PunctuationLeaf");
            UnicodeCategory unicodeCategory;
            bool isPreviousWord = false;
            bool spaceBeforeSign;
            bool spaceAfterSign = false;
            StringBuilder stringBuilder = new StringBuilder();
            var sortedSentenceItems = (from sentenceItem in this.SentenceItemsCollection orderby sentenceItem.SentencePosition select sentenceItem);
            foreach (var sentenceItem in sortedSentenceItems)
            {
                if (sentenceItem.GetType() != type)
                {
                    if (isPreviousWord || (!isPreviousWord && spaceAfterSign))
                    {
                        stringBuilder.Append(' ');
                    }

                    isPreviousWord = true;
                }
                else
                {
                    ((PunctuationLeaf)sentenceItem).RequireSpaces(out spaceBeforeSign, out spaceAfterSign);
                    if ((spaceBeforeSign && isPreviousWord) || (!isPreviousWord && spaceAfterSign))
                    {
                        stringBuilder.Append(' ');
                    }

                    isPreviousWord = false;
                }

                stringBuilder.Append(sentenceItem.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}