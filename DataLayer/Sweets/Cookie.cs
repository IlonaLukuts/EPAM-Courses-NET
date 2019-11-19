
namespace DataLayer.Sweets
{
    using System;

    using DataLayer.Sweets.Enums;

    public class Cookie : Sweets, IEquatable<Cookie>
    {
        public Cookie(int id, string name, string producer, CookieType cookieType) :
            base(id, name, producer)
        {
            this.CookieType = cookieType;
            this.Sugar = 1.0;
            this.Weight = 5.0;
            this.Price = 10.0M;
        }

        public CookieType CookieType { get; private set; }

        public bool Equals(Cookie other)
        {
            return base.Equals(other) && this.CookieType.Equals(other.CookieType);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.CookieType.ToString()} cookie";
        }
    }
}
