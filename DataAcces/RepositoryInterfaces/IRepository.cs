using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetByPredicate(Func<TEntity, bool> predicate);
        Task DeleteById(Guid id);
        void Delete(TEntity item);
    }
}
