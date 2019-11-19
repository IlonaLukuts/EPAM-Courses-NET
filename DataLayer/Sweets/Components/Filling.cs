
namespace DataLayer.Sweets.Components
{
    using System;

    public class Filling : SweetDecorator, IEquatable<Filling>
    {
        public Filling(Sweets sweets, string fillingName) : base(sweets)
        {
            this.FillingName = fillingName;
            this.Sugar = this.Sweets.Sugar + 0.4;
            this.Weight = this.Sweets.Weight + 1.0;
            this.Price = this.Sweets.Price + 0.5M;
        }

        public string FillingName { get; private set; }

        public bool Equals(Filling other)
        {
            return base.Equals(other) && this.FillingName.Equals(other.FillingName);
        }

        public override string ToString()
        {
            return $"{base.ToString()} with {this.FillingName} filling";
        }
    }
}
