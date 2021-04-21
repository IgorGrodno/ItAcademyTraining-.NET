using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IUserRoleRepository : IRepository<UserRoleEntity>
    {
        Task Add(Guid userId, Guid roleId);
        Task Delete(Guid userId, Guid roleId);
        Task<Guid> GetRoleIdByUserId(Guid userId);
    }
}
