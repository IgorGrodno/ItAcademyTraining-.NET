using System;
using System.Threading.Tasks;
using System.Web;

namespace Services.ServiceInterfaces
{
    public interface IFileManager : IDisposable
    {
        Task AddPicture(HttpPostedFileBase file, Guid pictureId);
        Task<byte[]> GetPicture(Guid id);
    }
}
