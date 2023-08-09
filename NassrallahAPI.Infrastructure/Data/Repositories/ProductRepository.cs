using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NassrallahAPI.Application.Repositories;
using NassrallahAPI.Domain.Entities;
using NassrallahAPI.Shared.Exceptions;

namespace NassrallahAPI.Infrastructure.Data.Repositories
{
    internal class ProductRepository: BaseRepository<Product>, IProductRepository
    {
        private readonly AppDBContext _context;
        private readonly DbSet<Product> _products;

        public ProductRepository(AppDBContext context) :base(context)
        {
            _context = context;
            _products = _context.Set<Product>();
        }
        public async Task<List<Product>> GetWholeAsync(CancellationToken cancellationToken)
            =>await _products.ToListAsync(cancellationToken);
        public async Task<Product> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _products.FirstOrDefaultAsync(i => i.Id == id, cancellationToken)
            ?? throw new NotFoundException(id);

    }
}
