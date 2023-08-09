using Microsoft.EntityFrameworkCore;
using NassrallahAPI.Application.Repositories;
using NassrallahAPI.Domain.Entities;
using NassrallahAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Infrastructure.Data.Repositories
{ 
    internal class OrderRepository:BaseRepository<Order>,IOrderRepository
    {
        private readonly AppDBContext _context;
        private readonly DbSet<Order> _Order;
        public OrderRepository(AppDBContext context):base(context)
        {
            _context = context;
            _Order = _context.Set<Order>();
        }

        public async Task<List<Order>> GetWholeAsync(CancellationToken cancellationToken)
            => await _Order.ToListAsync(cancellationToken);
        public async Task<Order> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _Order.FirstOrDefaultAsync(i => i.Id == id, cancellationToken)
            ?? throw new NotFoundException(id);
    }
}
