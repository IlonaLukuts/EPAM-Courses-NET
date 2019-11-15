using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets.Components
{
    public enum ToppingShape
    {
        Balls,
        Hearts,
        Stars,
        Snowflakes,
        Rectangles,
        Butterflies,
        Flowers,
        Diamonds,
        Fruits,
        Different
    }

    public class Topping : SweetDecorator
    {
        public ToppingShape Shape { get; private set; }
        public string ToppingColor { get; private set; }
        public Topping(Sweets sweets, ToppingShape toppingShape, string toppingColor) : base(sweets)
        {
            this.Shape = toppingShape;
            this.ToppingColor = toppingColor;
            this.Sugar = this.Sweets.Sugar + 0.2;
            this.Weight = this.Sweets.Weight + 0.01;
            this.Price = this.Sweets.Price + 0.02M;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.ToppingColor + " " + this.Shape.ToString();
        }
    }
}
