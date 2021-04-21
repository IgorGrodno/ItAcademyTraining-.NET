using DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IUserClaimRepository : IRepository<UserClaimEntity>
    {
        Task Add(Guid userId, Guid claimId);
        Task Delete(Guid userId, Guid claimId);
        Task<IEnumerable<Guid>> GetClaimsId(Guid userId);
    }
}
