using DataAcces;
using Domain.DTO;
using Services.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ExternalLoginService : IExternalLoginService
    {
        private readonly IUnitOfWorkFactory _factory;

        public ExternalLoginService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public async Task DeleteById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {

                await unitOfWork.Logins.DeleteById(id);
                await unitOfWork.Commit();
            }
        }

        public async Task<ExternalLogin> GetById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {

                return await unitOfWork.Logins.GetById(id);
            }
        }

        public async Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Logins.GetByProviderAndKey(loginProvider, providerKey);
            }
        }

        public async Task Update(ExternalLogin item)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Logins.Update(item);
                await unitOfWork.Commit();
            }
        }

    }
}
