namespace Nassrallah_Product
{
    using System;
    using System.Collections.Generic;
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
            public decimal Price { get; set; }
        public int Quantity { get; set; }

            public Product(string name, string description, decimal price, int quantity)
            {
                Name = name;
                Description = description;
                Price = price;
                Quantity = quantity;
            }
            public void Update(string name, string description, decimal price, int quantity)
        {
            Id= id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
    }
} 

