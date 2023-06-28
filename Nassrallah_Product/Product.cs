namespace Nassrallah_Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, string description, int price, int quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
    }
}
