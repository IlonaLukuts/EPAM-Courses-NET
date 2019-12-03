namespace DataLayer.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    public class ParagraphComposite : TextComponent, IEquatable<ParagraphComposite>, IParagraph
    {
        private bool isThereLineBreak;

        public ParagraphComposite()
        {
            this.SentencesCollection = new Collection<ISentence>();
            this.isThereLineBreak = false;
        }

        public ICollection<ISentence> SentencesCollection { get; }

        public bool AddSentence(ISentence paragraph)
        {
            this.SentencesCollection.Add(paragraph);
            return true;
        }

        public bool DeleteSentence(ISentence paragraph)
        {
            this.SentencesCollection.Remove(paragraph);
            return true;
        }

        public void SetLineBreak()
        {
            this.isThereLineBreak = true;
        }

        public bool Equals(ParagraphComposite other)
        {
            return base.Equals(other)
                   && (from sentence in this.SentencesCollection select sentence).All(other.SentencesCollection.Contains)
                   && this.SentencesCollection.Count.Equals(other.SentencesCollection.Count)
                   && this.isThereLineBreak.Equals(other.isThereLineBreak);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var sortedSentences = (from sentence in this.SentencesCollection orderby sentence.Id select sentence);
            foreach (var sentence in sortedSentences)
            {
                stringBuilder.Append(sentence.ToString());
                stringBuilder.Append(' ');
            }

            return stringBuilder.ToString();
        }
    }
}