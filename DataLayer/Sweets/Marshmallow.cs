using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets
{
    public enum MarshmallowType
    {
        RussianPaste,
        FrenchMarshmallow,
        AmericanMarshmallow
    }
    public class Marshmallow : Sweets
    {
        public MarshmallowType MarshmallowType { get; private set; }
        public string Taste { get; private set; }

        public Marshmallow(int id, string name, string producer,
            MarshmallowType marshmallowType, string taste) :
            base(id, name, producer)
        {
            this.MarshmallowType = marshmallowType;
            this.Taste = taste;
            this.Sugar = 15.0;
            this.Weight = 8.0;
            this.Price = 6.5M;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.MarshmallowType.ToString() + " with taste of " + this.Taste;
        }
    }
}
