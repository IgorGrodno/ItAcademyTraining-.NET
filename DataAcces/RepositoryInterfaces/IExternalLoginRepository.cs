using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IExternalLoginRepository : IRepository<ExternalLoginEntity>
    {
        Task<ExternalLogin> GetById(Guid id);
        void Add(ExternalLogin item);
        Task Update(ExternalLogin item);
        Task<ExternalLogin> GetByProviderAndKey(string loginProvider, string providerKey);
    }
}
