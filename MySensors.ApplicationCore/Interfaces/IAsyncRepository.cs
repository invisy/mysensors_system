using System.Collections.Generic;
using System.Threading.Tasks;
using MySensors.ApplicationCore.Entities;
using Ardalis.Specification;
using MySensors.ApplicationCore.Interfaces;

namespace MySensors.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<TKey, TEntity> : IRepository where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<int> CountAsync(ISpecification<TEntity> spec);
        Task<TEntity> FirstAsync(ISpecification<TEntity> spec);
        Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec);
    }
}