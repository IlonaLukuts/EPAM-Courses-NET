using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets.Components
{
    class SweetDecorator : Sweets
    {
        protected Sweets Sweets;
        
        protected SweetDecorator(Sweets sweets)
        {
            this.Sweets = sweets;
        }

        protected
    }
}
