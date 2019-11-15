using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets
{
    public enum CakeType
    {
        Biscuit,
        Shortbread, //pesocznoe
        Puff, //sloenoe
        Brewing, //zavarnoe
        Air,
        Walnut, //orehovoe
        Crumble, //kroshkovoe
        Whipped, //sbityj
        Almond //mindalnoe
    }
    public class Cake : Sweets
    {
        public CakeType CakeType { get; private set; }
        public Cake(int id, string name, string producer,
            CakeType cakeType) :
            base(id, name, producer)
        {
            this.CakeType = cakeType;
            this.Sugar = 10.0;
            this.Weight = 5.0;
            this.Price = 30.0M;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.CakeType.ToString() + " cake";
        }
    }
}
