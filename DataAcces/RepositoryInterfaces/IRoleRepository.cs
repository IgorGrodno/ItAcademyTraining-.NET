using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IRoleRepository : IRepository<RoleEntity>
    {
        Task<Role> GetById(Guid id);
        Task<Role> GetByName(string name);
        void Add(Role item);
        Task Update(Role item);
    }
}
