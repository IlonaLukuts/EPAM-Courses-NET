namespace DataLayer.Impl
{
    public abstract class TextComponent : ITextComponent
    {
        public int Id { get; set; }

        public int StartLinePosition { get; set; }

        public virtual bool Equals(ITextComponent other)
        {
            return this.Id == other.Id && this.StartLinePosition == other.StartLinePosition;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}