using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets.Components
{
    public class Berries : SweetDecorator
    {
        public int BerryAmount { get; private set; }
        public string BerryName { get; private set; }
        public string BerryMadeOf { get; private set; }

        public Berries(Sweets sweets, int berryAmount, string berryName, string berryMadeOf) : base(sweets)
        {
            this.BerryAmount = berryAmount;
            this.BerryName = berryName;
            this.BerryMadeOf = berryMadeOf;
            this.Sugar = this.Sweets.Sugar + 0.1;
            this.Weight = this.Sweets.Weight + 0.1;
            this.Price = this.Sweets.Price + 0.1M;
        }

        public override string ToString()
        {
            return base.ToString() + " with " + this.BerryAmount + " " + this.BerryMadeOf + " " + this.BerryName;
        }
    }
}
