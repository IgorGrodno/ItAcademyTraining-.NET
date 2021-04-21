using Domain.DTO;
using System.Threading.Tasks;

namespace Services.ServiceInterfaces
{
    public interface IExternalLoginService : IService<ExternalLogin>
    {
        Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey);
    }
}
