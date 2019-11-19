
namespace DataLayer.Sweets.Components
{
    using System;

    public class Prediction : SweetDecorator, IEquatable<Prediction>
    {
        public Prediction(Sweets sweets, string predictionText) : base(sweets)
        {
            this.PredictionText = predictionText;
            this.Sugar = this.Sweets.Sugar + 0.4;
            this.Weight = this.Sweets.Weight + 1.0;
            this.Price = this.Sweets.Price + 0.5M;
        }

        public string PredictionText { get; private set; }

        public bool Equals(Prediction other)
        {
            return base.Equals(other) && this.PredictionText.Equals(other.PredictionText);
        }

        public override string ToString()
        {
            return $"{base.ToString()} with prediction: \"{this.PredictionText}\"";
        }
    }
}
