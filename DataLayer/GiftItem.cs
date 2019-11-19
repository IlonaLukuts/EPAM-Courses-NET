
namespace DataLayer
{
    using System;

    public abstract class GiftItem : IGiftItem, IEquatable<GiftItem>
    {
        protected GiftItem()
        {
        }
        
        protected GiftItem(int id, string name, string producer)
        {
            this.Id = id;
            this.Name = name;
            this.Producer = producer;
            this.Weight = 0.0;
            this.Price = 0.0M;
        }

        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string Producer { get; protected set; }

        public double Weight { get; protected set; }

        public decimal Price { get; protected set; }


        public override string ToString()
        {
            return $"{this.Id} {this.Name} {this.Producer} {this.Weight}g {this.Price}BYN";
        }

        public bool Equals(GiftItem other)
        {
            return this.Id.Equals(other.Id) && this.Name.Equals(other.Name) && this.Producer.Equals(other.Producer)
                   && this.Price.Equals(other.Price) && this.Weight.Equals(other.Weight);
        }
    }
}
