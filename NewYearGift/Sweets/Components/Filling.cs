using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets.Components
{
    class Filling : SweetDecorator
    {
        public string Name { get; private set; }
        public Filling(Sweets sweets, string fillingName) : base(sweets)
        {
            this.Name = fillingName;
        }
    }
}
