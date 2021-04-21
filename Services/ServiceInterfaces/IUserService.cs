using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ServiceInterfaces
{
    public interface IUserService : IService<User>
    {
        Task Add(User user);
        Task AddSeting(UserSeting seting);
        Task ClearSetings(Guid userId);
        Task<User> GetByName(string name);
        Task AddClaim(Guid userId, Claim claim);
        Task<IEnumerable<Claim>> GetClaims(Guid userId);
        Task RemoveClaim(Guid userId, Claim claim);
        Task AddLogin(Guid userId, ExternalLogin login);
        Task<User> GetByProviderAndKey(string loginProvider, string providerKey);
        Task<IEnumerable<ExternalLogin>> GetLogins(Guid userId);
        Task RemoveLogin(Guid userId, string loginProvider, string providerKey);
        Task AddToRole(Guid userId, string roleName);
        Task<Role> GetRole(Guid userId);
        Task<bool> IsInRole(Guid userId, string roleName);
        Task RemoveFromRole(Guid userId, string roleName);
        IQueryable<User> GetAll();
        Task <IEnumerable<UserSeting>> GetSetings(Guid userId);
    }
}
