using NassrallahAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>    
    {
        Task<List<Order>> GetWholeAsync(CancellationToken cancellationToken);
        Task<Order> GetWholeByIdAsync(int id,CancellationToken cancellationToken);
    }
}
