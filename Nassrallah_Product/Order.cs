namespace Nassrallah_Product
{
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations.Schema;
        public class Order
        {

            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal TotalAmount { get; set; }
            [ForeignKey("Product")]
            public int ProductId { get; set; }
            public List<Product> Products { get; } = new();

            public Order(int productId, decimal totalAmount)
            {
                OrderDate = DateTime.Now;
                TotalAmount = totalAmount;
                ProductId = productId;
            }

            public void Update(int productId, decimal totalAmount)
            {
                ProductId = productId;
                TotalAmount = totalAmount;
            }
        }

    
}
