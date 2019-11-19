
namespace DataLayer.Sweets.Components
{
    using System;

    public class Berries : SweetDecorator, IEquatable<Berries>
    {
        public Berries(Sweets sweets, int berryAmount, string berryName, string berryMadeOf) : base(sweets)
        {
            this.BerryAmount = berryAmount;
            this.BerryName = berryName;
            this.BerryMadeOf = berryMadeOf;
            this.Sugar = this.Sweets.Sugar + 0.1;
            this.Weight = this.Sweets.Weight + 0.1;
            this.Price = this.Sweets.Price + 0.1M;
        }

        public int BerryAmount { get; private set; }

        public string BerryName { get; private set; }

        public string BerryMadeOf { get; private set; }

        public bool Equals(Berries other)
        {
            return base.Equals(other) && this.BerryAmount.Equals(other.BerryAmount)
                                      && this.BerryName.Equals(other.BerryName)
                                      && this.BerryMadeOf.Equals(other.BerryMadeOf);
        }

        public override string ToString()
        {
            return $"{base.ToString()} with {this.BerryAmount} {this.BerryMadeOf} {this.BerryName}";
        }
    }
}
