using Domain.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ServiceInterfaces
{
    public interface IGenreService : IService<Genre>
    {
        Task Add(Genre genre);

        IQueryable<Genre> GetAll();
    }
}
