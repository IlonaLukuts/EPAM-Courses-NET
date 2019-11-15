using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets.Components
{
    public enum CookieType
    {
        Sugar,
        Dry,
        Shortbread,
        Puff,
        Whipped,
        Oatmeal
    }
    public class Cookie : Sweets
    {
        public CookieType CookieType { get; private set; }
        public Cookie(int id, string name, string producer,
            CookieType cookieType) :
            base(id, name, producer)
        {
            this.CookieType = cookieType;
            this.Sugar = 10.0;
            this.Weight = 5.0;
            this.Price = 30.0M;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.CookieType.ToString() + " cookie";
        }
    }
}
