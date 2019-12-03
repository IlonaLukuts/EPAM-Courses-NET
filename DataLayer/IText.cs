namespace DataLayer
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    using DataLayer.Impl;

    public interface IText : ITextComponent
    {
        ICollection<IParagraph> ParagraphsCollection { get; }

        bool AddParagraph(IParagraph paragraph);

        bool DeleteParagraph(IParagraph paragraph);
        
        void SetPageBreak();
    }
}