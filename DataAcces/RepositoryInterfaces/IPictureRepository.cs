using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IPictureRepository : IRepository<PictureEntity>
    {
        Task<Picture> GetById(Guid id);
        void Add(Picture item);
        Task Update(Picture item);
        Task<List<Picture>> PageAll(int skip, int take);
        Task<List<Picture>> PageByGenreId(int skip, int take, Guid genreId);
        Task<List<Picture>> PageByRating(int skip, int take, int rating, bool isRatingMore);

        new IQueryable<Picture> GetAll();
    }
}
