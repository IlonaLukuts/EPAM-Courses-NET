using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets.Components
{
    public class SweetDecorator : Sweets
    {
        protected Sweets Sweets;
        
        protected SweetDecorator(Sweets sweets)
        {
            this.Sweets = sweets;
        }

        public bool ExistsComponent(Type type)
        {
            return true;
        }

        public override string ToString()
        {
            return Sweets.ToString();
        }
    }
}
