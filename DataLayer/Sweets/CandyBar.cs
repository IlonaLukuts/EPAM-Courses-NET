using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets
{
    public class CandyBar : Sweets
    {

        public CandyBar(int id, string name, string producer) :
            base(id, name, producer)
        {
            this.Sugar = 5.0;
            this.Weight = 2.5;
            this.Price = 15.0M;
        }

        public override string ToString()
        {
            return base.ToString() + " candy bar";
        }
    

    }
}
