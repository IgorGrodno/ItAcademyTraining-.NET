using System;
using System.Threading.Tasks;

namespace Services.ServiceInterfaces
{
    public interface IService<IDTO>
    {
        Task Update(IDTO item);
        Task DeleteById(Guid id);
        Task<IDTO> GetById(Guid id);

    }
}
