using Domain.DTO;
using System.Threading.Tasks;

namespace Services.ServiceInterfaces
{
    public interface IRoleService : IService<Role>
    {
        Task<Role> FindByName(string roleName);
        Task Add(Role item);
    }
}
