using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync(TEntity entity,CancellationToken cancellationToken);
        Task DeleteAsync(int id,CancellationToken cancellationToken);
    }
}
