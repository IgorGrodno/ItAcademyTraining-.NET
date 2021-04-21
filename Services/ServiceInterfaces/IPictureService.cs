using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ServiceInterfaces
{
    public interface IPictureService : IService<Picture>
    {
        Task Add(Picture picture);
        Task<List<Picture>> PageAll(int skip, int take);
        Task<List<Picture>> PageByGenre(int skip, int take, Guid genreId);
        Task ChangeRating(Picture picture, Guid? userId, bool isRatingIncressed, string ipAdress);
        IQueryable<Picture> GetAll();
    }
}
