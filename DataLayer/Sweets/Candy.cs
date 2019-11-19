
namespace DataLayer.Sweets
{
    using System;

    using DataLayer.Sweets.Enums;

    public class Candy : Sweets, IEquatable<Candy>
    {
        public Candy(int id, string name, string producer, CandyType candyType) :
            base(id, name, producer)
        {
            this.CandyType = candyType;
            this.Sugar = 10.0;
            this.Weight = 5.0;
            this.Price = 30.0M;
        }

        public CandyType CandyType { get; private set; }

        public bool Equals(Candy other)
        {
            return base.Equals(other) && this.CandyType.Equals(other.CandyType);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.CandyType.ToString()} candy"; 
        }
    }
}
