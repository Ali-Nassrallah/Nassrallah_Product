using Microsoft.EntityFrameworkCore;
using NassrallahAPI.Application.Repositories;
using NassrallahAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Infrastructure.Data.Repositories
{
    internal class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDBContext _Context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(AppDBContext context)
        {
            _Context = context;
            _dbSet= context.Set<TEntity>();
        }
        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
            => await _dbSet.ToListAsync(cancellationToken);
        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _dbSet.FindAsync(new object?[] { id }, cancellationToken)
            ?? throw new NotFoundException(id);
        
        public async Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken)
        {
            var createdEntity = await _dbSet.AddAsync(entity, cancellationToken);
            await _Context.SaveChangesAsync(cancellationToken);
            return createdEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity,CancellationToken cancellationToken)
        {
            var updatedEntity = _dbSet.Update(entity);
            await _Context.SaveChangesAsync(cancellationToken);
            return updatedEntity.Entity;
        }

        public async Task DeleteAsync(int id,CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            _dbSet.Remove(entity);
            await _Context.SaveChangesAsync(cancellationToken);
        }
    }

}
