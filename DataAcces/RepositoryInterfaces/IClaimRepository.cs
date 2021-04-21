using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IClaimRepository : IRepository<ClaimEntity>
    {
        Task<Claim> GetById(Guid id);
        void Add(Claim item);
        Task Update(Claim item);
    }
}
