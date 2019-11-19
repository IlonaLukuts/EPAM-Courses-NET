
namespace DataLayer.Sweets
{
    using System;

    public abstract class Sweets : GiftItem, IEquatable<Sweets>
    {
        protected Sweets()
        {
        }

        protected Sweets(int id, string name, string producer) :
            base(id, name, producer)
        {
            this.Sugar = 0.0;
        }

        public double Sugar { get; protected set; }


        public override string ToString()
        {
            return $"{base.ToString()} {this.Sugar}";
        }

        public bool Equals(Sweets other)
        {
            return base.Equals(other) &&
                this.Sugar.Equals(other.Sugar);
        }
    }
}
