
namespace DataLayer
{
    public class Toy : GiftItem
    {
        public Toy(int id, string name, string producer, string age, string size, string material) :
            base(id, name, producer)
        {
            this.Age = age;
            this.Size = size;
            this.Material = material;
            this.Weight = 300.0;
            this.Price = 1000.0M;
        }

        public string Age { get; private set; }

        public string Size { get; private set; }

        public string Material { get; private set; }
    }
}