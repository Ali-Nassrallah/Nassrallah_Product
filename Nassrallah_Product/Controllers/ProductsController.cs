using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nassrallah_Product;

namespace Nassrallah_Product.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
                          return await _context.Products.ToListAsync();
        }

        [HttpGet("{GetProductById}")]
        public async Task<Product> GetProductById(int id)
        {

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            return product;
        }

        [HttpPost("{AddProduct}")]
        public async Task<Product> AddNewProduct(string Name, string Description,decimal Price,int Quantity)
            {
            var newProduct = await _context.Products.AddAsync(new Product(Name, Description, Price, Quantity));
                await _context.SaveChangesAsync();
            return newProduct.Entity;

        }
        [HttpPut("{UpdateProduct}")]
        public async Task<Product> UpdateProductAsync(int Id,string Name, string Description, decimal Price, int Quantity)
            {
            var forUpdate = await _context.Products.FirstOrDefaultAsync(i => i.Id==Id);
             throw new Exception("Not Found");
            forUpdate.Update(Name, Description, Price, Quantity);
            await _context.SaveChangesAsync();
            return forUpdate;
            }
        [HttpDelete("{DeleteProductById}")]
        public async Task DeleteProductById(int Id)
        {
            var forDelete = await _context.Products.FirstOrDefaultAsync(i => i.Id == Id);
             throw new Exception("Not found");
            _context.Remove(forDelete);
            await _context.SaveChangesAsync();
        }
    }
}
