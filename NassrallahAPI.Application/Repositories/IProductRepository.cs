using NassrallahAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public Task<List<Product>> GetWholeAsync(CancellationToken cancellation);
        public Task<Product> GetWholeByIdAsync(int id,CancellationToken cancellation);
    }
}
