using DataAcces;
using Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using ExpressMapper.Extensions;
using DataAcces.Entities;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkFactory _factory;

        public UserService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public async Task Add(User user)
        {
            using (var unitOfWork = _factory.Create())
            {
                var userCheck = await unitOfWork.Users.GetByName(user.UserName);

                if (userCheck == null)
                {
                    unitOfWork.Users.Add(user);

                    await this.AddToRole(user.Id, "user");
                    await this.AddClaim(user.Id, unitOfWork.Claims.GetAll().FirstOrDefault().Map<ClaimEntity, Claim>());
                    await unitOfWork.Commit();
                }
            }
        }

        public async Task DeleteById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Users.DeleteById(id);
                await unitOfWork.Commit();
            }
        }

        public async Task<User> GetByName(string name)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Users.GetByName(name);
            }
        }

        public async Task<User> GetById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Users.GetById(id);
            }
        }

        public async Task AddClaim(Guid userId, Claim claim)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.UserClaims.Add(userId, claim.Id);
                await unitOfWork.Commit();
            }
        }

        public async Task Update(User item)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Users.Update(item);
                await unitOfWork.Commit();
            }
        }

        public async Task<IEnumerable<Claim>> GetClaims(Guid userId)
        {
            using (var unitOfWork = _factory.Create())
            {
                List<Claim> result = new List<Claim>();

                foreach (var item in await unitOfWork.UserClaims.GetClaimsId(userId))
                {
                    result.Add(await unitOfWork.Claims.GetById(item));
                }

                return result;
            }
        }

        public async Task RemoveClaim(Guid userId, Claim claim)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.UserClaims.Delete(userId, claim.Id);
                await unitOfWork.Commit();
            }
        }

        public async Task AddLogin(Guid userId, ExternalLogin login)
        {
            using (var unitOfWork = _factory.Create())
            {
                unitOfWork.Logins.Add(login);
                await unitOfWork.UserLogins.Add(userId, login.Id);

                await unitOfWork.Commit();
            }
        }

        public async Task<User> GetByProviderAndKey(string loginProvider, string providerKey)
        {
            using (var unitOfWork = _factory.Create())
            {
                var login = await unitOfWork.Logins.GetByProviderAndKey(loginProvider, providerKey);
                var userId = await unitOfWork.UserLogins.GetUserId(login.Id);
                return await unitOfWork.Users.GetById(userId);
            }
        }

        public async Task<IEnumerable<ExternalLogin>> GetLogins(Guid userId)
        {
            using (var unitOfWork = _factory.Create())
            {
                List<ExternalLogin> result = new List<ExternalLogin>();

                foreach (var item in await unitOfWork.UserLogins.GetLoginsId(userId))
                {
                    result.Add(await unitOfWork.Logins.GetById(item));
                }

                return result;
            }
        }

        public async Task RemoveLogin(Guid userId, string loginProvider, string providerKey)
        {
            using (var unitOfWork = _factory.Create())
            {
                var login = await unitOfWork.Logins.GetByProviderAndKey(loginProvider, providerKey);
                await unitOfWork.UserLogins.Delete(userId, login.Id);
                await unitOfWork.Commit();
            }
        }

        public async Task AddToRole(Guid userId, string roleName)
        {
            using (var unitOfWork = _factory.Create())
            {
                var role = await unitOfWork.Roles.GetByName(roleName);
                await unitOfWork.UserRoles.Add(userId, role.Id);
                await unitOfWork.Commit();
            }
        }

        public async Task<Role> GetRole(Guid userId)
        {
            using (var unitOfWork = _factory.Create())
            {
                var roleId = await unitOfWork.UserRoles.GetRoleIdByUserId(userId);
                return await unitOfWork.Roles.GetById(roleId);
            }
        }
        public async Task<bool> IsInRole(Guid userId, string roleName)
        {
            bool result = false;
            var role = await this.GetRole(userId);
            if (role.Name == roleName)
            {
                result = true;
            }
            return result;
        }

        public async Task RemoveFromRole(Guid userId, string roleName)
        {
            using (var unitOfWork = _factory.Create())
            {
                var role = await unitOfWork.Roles.GetByName(roleName);
                await unitOfWork.UserRoles.Delete(userId, role.Id);

                await unitOfWork.Commit();
            }
        }

        public IQueryable<User> GetAll()
        {
            using (var unitOfWork = _factory.Create())
            {
                return unitOfWork.Users.GetAll();
            }
        }

        public async Task<IEnumerable<UserSeting>> GetSetings(Guid userId)
        {
            using (var unitOfWork = _factory.Create())
            {
                return unitOfWork.Setings.GetByUserId(userId);
            }
        }


        public async Task AddSeting(UserSeting seting)
        {
            using (var unitOfWork = _factory.Create())
            {
                unitOfWork.Setings.Add(seting);
                await unitOfWork.Commit();
            }
        }

        public async Task ClearSetings(Guid userId)
        {
            using (var unitOfWork = _factory.Create())
            {
                var items = unitOfWork.Setings.GetByUserId(userId).ToList();
                foreach (var item in items)
                {
                    await unitOfWork.Setings.DeleteById(item.Id);
                }
                await unitOfWork.Commit();
            }
        }
    }
}
