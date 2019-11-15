﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets.Components
{
    public class Filling : SweetDecorator
    {
        public string FillingName { get; private set; }
        public Filling(Sweets sweets, string fillingName) : base(sweets)
        {
            this.FillingName = fillingName;
            this.Sugar = this.Sweets.Sugar + 0.4;
            this.Weight = this.Sweets.Weight + 1.0;
            this.Price = this.Sweets.Price + 0.5M;
        }

        public override string ToString()
        {
            return base.ToString() + " with " + FillingName + " filling";
        }
    }
}
