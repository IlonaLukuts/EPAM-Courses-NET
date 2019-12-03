namespace DataLayer
{
    using System;

    public interface ITextComponent : IEquatable<ITextComponent>
    {
        int Id { get; set; }

        int StartLinePosition { get; set; }

        string ToString();
    }
}