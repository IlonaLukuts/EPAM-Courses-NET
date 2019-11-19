
namespace DataLayer.Sweets
{
    using System;

    public class CandyBar : Sweets, IEquatable<CandyBar>
    {

        public CandyBar(int id, string name, string producer) :
            base(id, name, producer)
        {
            this.Sugar = 50.0;
            this.Weight = 45;
            this.Price = 45.0M;
        }

        public bool Equals(CandyBar other)
        {
            return base.Equals(other);
        }

        public override string ToString()
        {
            return $"{base.ToString()} candy bar";
        }
    

    }
}
