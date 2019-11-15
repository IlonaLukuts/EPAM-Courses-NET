using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets
{
    public class Marmalade : Sweets
    {
        public string Taste { get; private set; }
        public Marmalade(int id, string name, string producer,
            string taste) :
            base(id, name, producer)
        {
            this.Taste = taste;
            this.Sugar = 5.0;
            this.Weight = 2.5;
            this.Price = 15.0M;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Taste + " marmalade";
        }
    }
}
