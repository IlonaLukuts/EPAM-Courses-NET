using System;

namespace DataLayer
{
    public abstract class GiftItem
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Producer { get; protected set; }
        public double Weight { get; protected set; }
        public decimal Price { get; protected set; }

        protected GiftItem() { }
        protected GiftItem(int id, string name, string producer)
        {
            this.Id = id;
            this.Name = name;
            this.Producer = producer;
            this.Weight = 0.0;
            this.Price = 0.0M;
        }

    }
}
