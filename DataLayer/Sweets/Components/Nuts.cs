
namespace DataLayer.Sweets.Components
{
    using System;

    public class Nuts : SweetDecorator, IEquatable<Nuts>
    {
        public Nuts(Sweets sweets, string nutsName, bool isCrushed) : base(sweets)
        {
            this.NutsName = nutsName;
            this.IsCrushed = isCrushed;
            this.Sugar = this.Sweets.Sugar + 0.1;
            this.Weight = this.Sweets.Weight + 0.1;
            this.Price = this.Sweets.Price + 0.1M;
        }

        public string NutsName { get; private set; }
        
        public bool IsCrushed { get; private set; }

        public bool Equals(Nuts other)
        {
            return base.Equals(other) && this.NutsName.Equals(other.NutsName) && this.IsCrushed.Equals(other.IsCrushed);
        }

        public override string ToString()
        {
            string str = $"{base.ToString()} with ";
            if (this.IsCrushed)
            {
                str += "crushed ";
            }

            return $"{str} {this.NutsName}";
        }
    }
}
