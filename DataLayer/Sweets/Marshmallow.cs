
namespace DataLayer.Sweets
{
    using System;
    using DataLayer.Sweets.Enums;

    public class Marshmallow : Sweets, IEquatable<Marshmallow>
    {
        public Marshmallow(int id, string name, string producer, MarshmallowType marshmallowType, string taste)
            : base(id, name, producer)
        {
            this.MarshmallowType = marshmallowType;
            this.Taste = taste;
            this.Sugar = 15.0;
            this.Weight = 8.0;
            this.Price = 6.5M;
        }

        public MarshmallowType MarshmallowType { get; private set; }

        public string Taste { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} {this.MarshmallowType.ToString()} with taste of {this.Taste}";
        }

        public bool Equals(Marshmallow other)
        {
            return base.Equals(other) &&
                this.MarshmallowType.Equals(other.MarshmallowType) &&
                this.Taste.Equals(other.Taste);
        }
    }
}
