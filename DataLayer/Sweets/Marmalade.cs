
namespace DataLayer.Sweets
{
    using System;

    public class Marmalade : Sweets, IEquatable<Marmalade>
    {
        public Marmalade(int id, string name, string producer, string taste)
            : base(id, name, producer)
        {
            this.Taste = taste;
            this.Sugar = 5.0;
            this.Weight = 2.5;
            this.Price = 15.0M;
        }

        public string Taste { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Taste} marmalade";
        }

        public bool Equals(Marmalade other)
        {
            return base.Equals(other) &&
                this.Taste.Equals(other.Taste);
        }
    }
}
