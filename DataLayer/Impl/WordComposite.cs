namespace DataLayer.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    public class WordComposite : TextComponent, ISentenceItem, IEquatable<WordComposite>, IWord
    {
        private bool isThereLineBreak;

        public WordComposite()
        {
            this.LettersCollection = new Collection<ILetter>();
            this.isThereLineBreak = false;
            this.HasDash = false;
        }

        public bool HasDash { get; private set; }
        
        public ICollection<ILetter> LettersCollection { get; }

        public int SentencePosition { get; set; }


        public bool AddLetter(ILetter letter)
        {
            this.LettersCollection.Add(letter);
            return true;
        }

        public bool DeleteLetter(ILetter letter)
        {
            return this.LettersCollection.Remove(letter);
        }

        public void SetLineBreak()
        {
            this.isThereLineBreak = true;
        }

        public void SetDash()
        {
            this.HasDash = true;
        }

        public bool Equals(WordComposite other)
        {
            return base.Equals(other)
                   && (from letter in this.LettersCollection select letter).All(other.LettersCollection.Contains)
                   && this.LettersCollection.Count.Equals(other.LettersCollection.Count)
                   && this.SentencePosition.Equals(other.SentencePosition)
                   && this.isThereLineBreak.Equals(other.isThereLineBreak);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var letter in this.LettersCollection)
            {
                stringBuilder.Append(letter.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}