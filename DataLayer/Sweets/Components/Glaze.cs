using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets.Components
{
    public class Glaze : SweetDecorator
    {
        public string GlazeName { get; private set; }
        public Glaze(Sweets sweets, string glazeName) : base(sweets)
        {
            this.GlazeName = glazeName;
            this.Sugar = this.Sweets.Sugar + 0.2;
            this.Weight = this.Sweets.Weight + 0.01;
            this.Price = this.Sweets.Price + 0.01M;
        }

        public override string ToString()
        {
            return base.ToString() + " with " + GlazeName + " glaze";
        }
    }
}
