using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Sweets.Components
{
    public class Prediction : SweetDecorator
    {
        public string PredictionText { get; private set; }
        public Prediction(Sweets sweets, string predictionText) : base(sweets)
        {
            this.PredictionText = predictionText;
            this.Sugar = this.Sweets.Sugar + 0.4;
            this.Weight = this.Sweets.Weight + 1.0;
            this.Price = this.Sweets.Price + 0.5M;
        }

        public override string ToString()
        {
            return base.ToString() + " with prediction: \"" + this.PredictionText + '\"';
        }
    }
}
