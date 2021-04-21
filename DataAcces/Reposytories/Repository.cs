using DataAcces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public IEnumerable<TEntity> GetByPredicate(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task DeleteById(Guid id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
        }
    }
}
