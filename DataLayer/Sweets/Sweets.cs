using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets
{
    public class Sweets: GiftItem
    {
        public double Sugar { get; protected set; }

        protected Sweets() { }
        protected Sweets(int id, string name, string producer) :
            base(id, name, producer)
        {
            this.Sugar = 0.0;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Sugar;
        }
    }
}
