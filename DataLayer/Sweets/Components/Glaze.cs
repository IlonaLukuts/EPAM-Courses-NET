
namespace DataLayer.Sweets.Components
{
    using System;

    public class Glaze : SweetDecorator, IEquatable<Glaze>
    {
        public Glaze(Sweets sweets, string glazeName) : base(sweets)
        {
            this.GlazeName = glazeName;
            this.Sugar = this.Sweets.Sugar + 0.2;
            this.Weight = this.Sweets.Weight + 0.01;
            this.Price = this.Sweets.Price + 0.01M;
        }

        public string GlazeName { get; private set; }

        public bool Equals(Glaze other)
        {
            return base.Equals(other) && this.GlazeName.Equals(other.GlazeName);
        }

        public override string ToString()
        {
            return $"{base.ToString()} with {this.GlazeName} glaze";
        }
    }
}
