namespace Cafe
{
    public class Item
    {
        public string Name { get; private set; }
        public Temperature Temperature { get; private set; }
        public decimal Price { get; private set; }
        public Sustenance Sustenance { get; private set; }

        public Item(string name, Temperature temperature, decimal price, Sustenance sustenance)
        {
            Name = name;
            Temperature = temperature;
            Price = price;
            Sustenance = sustenance;
        }
    }
}