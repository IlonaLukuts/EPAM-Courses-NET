namespace DataLayer.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    public class TextComposite : TextComponent, IEquatable<TextComposite>, IText
    {
        private bool isTherePageBreak;

        public TextComposite()
        {
            this.ParagraphsCollection = new Collection<IParagraph>();
            this.isTherePageBreak = false;
        }

        public ICollection<IParagraph> ParagraphsCollection { get; }

        public bool AddParagraph(IParagraph paragraph)
        {
            this.ParagraphsCollection.Add(paragraph);
            return true;
        }

        public bool DeleteParagraph(IParagraph paragraph)
        {
            this.ParagraphsCollection.Remove(paragraph);
            return true;
        }

        public void SetPageBreak()
        {
            this.isTherePageBreak = true;
        }

        public bool Equals(TextComposite other)
        {
            return base.Equals(other)
                   && (from paragraph in this.ParagraphsCollection select paragraph).All(other.ParagraphsCollection.Contains)
                   && this.ParagraphsCollection.Count.Equals(other.ParagraphsCollection.Count)
                   && this.isTherePageBreak.Equals(other.isTherePageBreak);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var sortedParagraphs = (from paragraph in this.ParagraphsCollection orderby paragraph.Id select paragraph);
            foreach (var paragraph in sortedParagraphs)
            {
                stringBuilder.Append(paragraph.ToString());
                stringBuilder.Append('\n');
            }

            return stringBuilder.ToString();
        }
    }
}