
namespace DataLayer.Sweets.Components
{
    using System;

    using DataLayer.Sweets.Components.Enums;

    public class Topping : SweetDecorator, IEquatable<Topping>
    {
        public Topping(Sweets sweets, ToppingShape toppingShape, string toppingColor) : base(sweets)
        {
            this.Shape = toppingShape;
            this.ToppingColor = toppingColor;
            this.Sugar = this.Sweets.Sugar + 0.2;
            this.Weight = this.Sweets.Weight + 0.01;
            this.Price = this.Sweets.Price + 0.02M;
        }

        public ToppingShape Shape { get; private set; }
        
        public string ToppingColor { get; private set; }

        public bool Equals(Topping other)
        {
            return base.Equals(other) && this.Shape.Equals(other.Shape) && this.ToppingColor.Equals(other.ToppingColor);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.ToppingColor} {this.Shape.ToString()}";
        }
    }
}
