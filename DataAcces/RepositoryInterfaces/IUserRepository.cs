using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<User> GetById(Guid id);
        void Add(User item);
        Task Update(User item);
        Task<User> GetByName(string name);
        new IQueryable<User> GetAll();
    }
}
