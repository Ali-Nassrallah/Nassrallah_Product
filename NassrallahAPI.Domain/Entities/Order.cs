﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Domain.Entities
{
    public class Order
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public List<Product> Products { get; } = new List<Product>();
        private Order() { }
        public Order(int totalAmount,List<Product> products)
        {
            OrderDate = DateTime.Now;
            TotalAmount = totalAmount;
            Products = products;
        }

        public void Update(int totalAmount)
        {
            TotalAmount = totalAmount;
        }
    }
}
