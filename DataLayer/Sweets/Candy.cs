using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets
{
    public enum CandyType
    {
        Lollipops,
        Waffle,
        Chocolate,
        Toffee,
        Pop,
        Chewing,
        Other
    }
    public class Candy : Sweets
    {
        public CandyType CandyType { get; private set; }

        public Candy(int id, string name, string producer,
            CandyType candyType) :
            base(id, name, producer)
        {
            this.CandyType = candyType;
            this.Sugar = 10.0;
            this.Weight = 5.0;
            this.Price = 30.0M;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.CandyType.ToString() + " candy"; 
        }
    }
}
