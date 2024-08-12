using ACME.Domain.Models.Interfaces;
using System.Linq.Expressions;

namespace ACME.Domain.Contracts
{
    public interface IBaseRepository<TEntity> 
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token);
        bool IsExist(Expression<Func<TEntity, bool>> expression, out TEntity entity);
        Task<IEntity> CreateAsync(TEntity entity, CancellationToken token);
        Task<IEntity> UpdateAsync(TEntity entity, CancellationToken token);
        Task DeleteAsync(TEntity entity, CancellationToken token);
    }
}
