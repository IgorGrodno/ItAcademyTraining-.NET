using DataAcces;
using Domain.DTO;
using Services.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWorkFactory _factory;

        public RoleService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public async Task Add(Role item)
        {
            using (var unitOfWork = _factory.Create())
            {
                var role = unitOfWork.Roles.GetByName(item.Name);
                if (role != null)
                {
                    unitOfWork.Roles.Add(item);
                    await unitOfWork.Commit();
                }
            }
        }

        public async Task DeleteById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Roles.DeleteById(id);
                await unitOfWork.Commit();
            }
        }

        public async Task<Role> FindByName(string roleName)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Roles.GetByName(roleName);
            }
        }

        public async Task<Role> GetById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Roles.GetById(id);
            }
        }

        public async Task Update(Role item)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Roles.Update(item);
                await unitOfWork.Commit();
            }
        }
    }
}
