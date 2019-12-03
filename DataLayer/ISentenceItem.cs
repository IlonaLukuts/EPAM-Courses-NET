namespace DataLayer
{
    public interface ISentenceItem : ITextComponent
    {
        int SentencePosition { get; set; }
    }
}