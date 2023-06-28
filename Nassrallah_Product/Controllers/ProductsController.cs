using Microsoft.AspNetCore.Mvc;

namespace Nassrallah_Product.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>();
        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        [HttpGet("GetById")]
        public Product GetById(int id)
        {
            var productFind = products.Find(p =>  p.Id == id);
                return productFind;
        }

        [HttpPost("AddProduct")]
        public void PostProduct(string name,string description,int price,int quantity)
        {
            Product p=new Product(name,description,price,quantity);

            p.Id = new Random().Next(1000, 9999);
            products.Add(p);
        }
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(int id,string newName,string newDescription,int price,int quantity)
        {
            var productFind = products.Find(p => p.Id == id);
            if (productFind != null)
            {
                productFind.Id= new Random().Next(1000, 9999); ;
                productFind.Name = newName;
                productFind.Description = newDescription;
                productFind.Price = price;
                productFind.Quantity = quantity;
                return Ok();
            }
            else
               return NotFound();

        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            var productFind = products.Find(p => p.Id == id);
            if (productFind != null)
            {
                products.Remove(productFind);
                return Ok();
            }
                
            else
                return NotFound();
        }
    }
}
