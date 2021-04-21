using DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IUserExternalLoginRepository : IRepository<UserExternalLoginEntity>
    {
        Task Add(Guid userId, Guid externalLoginId);
        Task Delete(Guid userId, Guid externalLoginId);
        Task<IEnumerable<Guid>> GetLoginsId(Guid userId);
        Task<Guid> GetUserId(Guid loginId);
    }
}
