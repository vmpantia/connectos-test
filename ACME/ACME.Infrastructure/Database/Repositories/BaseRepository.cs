using ACME.Domain.Contracts;
using ACME.Domain.Models.Interfaces;
using ACME.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACME.Infrastructure.Database.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly ACMEDbContext _context;
        protected readonly DbSet<TEntity> _table;
        public BaseRepository(ACMEDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll() => _table;

        public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression) => _table.Where(expression);

        public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token) =>
            await _table.FirstAsync(expression, token);

        public async Task<IEntity> CreateAsync(TEntity entity, CancellationToken token)
        {
            await _table.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);

            return entity;
        }

        public async Task<IEntity> UpdateAsync(TEntity entity, CancellationToken token)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync(token);

            return entity;
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken token)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync(token);
        }
    }
}
