using Microsoft.EntityFrameworkCore;

namespace Nassrallah_Product
{
    public class ProductDbContext: DbContext 
    {
        public ProductDbContext()
        {
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Order> Orders { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Products.db"));
        }
    }
}
