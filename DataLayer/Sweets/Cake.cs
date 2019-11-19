
namespace DataLayer.Sweets
{
    using System;

    using DataLayer.Sweets.Enums;

    public class Cake : Sweets, IEquatable<Cake>
    {
        public Cake(int id, string name, string producer, CakeType cakeType)
            : base(id, name, producer)
        {
            this.CakeType = cakeType;
            this.Sugar = 10.0;
            this.Weight = 100.0;
            this.Price = 100.0M;
        }

        public CakeType CakeType { get; private set; }

        public bool Equals(Cake other)
        {
            return base.Equals(other) && this.CakeType.Equals(other.CakeType);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.CakeType.ToString()} cake";
        }
    }
}
