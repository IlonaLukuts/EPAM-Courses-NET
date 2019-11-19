
namespace DataLayer.Sweets.Components
{
    using System;

    public abstract class SweetDecorator : Sweets, IEquatable<SweetDecorator>
    {
        protected Sweets Sweets;

        protected SweetDecorator(Sweets sweets)
        {
            this.Sweets = sweets;
        }

        public bool Equals(SweetDecorator other)
        {
            return this.Sweets.Equals(other.Sweets);
        }

        public override string ToString()
        {
            return this.Sweets.ToString();
        }
    }
}
