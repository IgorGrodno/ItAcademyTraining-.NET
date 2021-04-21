using DataAcces.Entities;
using DataAcces.RepositoryInterfaces;
using Domain.DTO;
using ExpressMapper.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    public class PictureRepository : Repository<PictureEntity>, IPictureRepository
    {
        public PictureRepository(DataContext context) : base(context)
        {
        }

        public void Add(Picture item)
        {
            base._dbSet.Add(item.Map<Picture, PictureEntity>());
        }


        public async Task<Picture> GetById(Guid id)
        {
            var result = await base._dbSet.FindAsync(id);
            return result.Map<PictureEntity, Picture>();
        }

        public async Task<List<Picture>> PageAll(int skip, int take)
        {
            var result = base._dbSet.OrderBy(x => x.AddingDate).Skip(skip).Take(take);
            List<PictureEntity> resultList = result.ToList();
            return resultList.Map<List<PictureEntity>, List<Picture>>();
        }

        public async Task<List<Picture>> PageByGenreId(int skip, int take, Guid genreId)
        {
            var result = base.GetByPredicate(x => x.GenreId == genreId).OrderBy(x => x.AddingDate).Skip(skip).Take(take);
            List<PictureEntity> resultList = result.ToList();
            return resultList.Map<List<PictureEntity>, List<Picture>>();
        }

        public async Task<List<Picture>> PageByRating(int skip, int take, int rating, bool isRatingMore)
        {
            if (isRatingMore)
            {
                var result = base.GetByPredicate(x => x.Rating >= rating).OrderBy(x => x.AddingDate).Skip(skip).Take(take);
                List<PictureEntity> resultList = result.ToList();
                return resultList.Map<List<PictureEntity>, List<Picture>>();
            }
            else
            {
                var result = base.GetByPredicate(x => x.Rating <= rating).OrderBy(x => x.AddingDate).Skip(skip).Take(take);
                List<PictureEntity> resultList = result.ToList();
                return resultList.Map<List<PictureEntity>, List<Picture>>();
            }
        }

        public async Task Update(Picture item)
        {
            var itemToUpdate = await base._dbSet.FindAsync(item.Id);

            itemToUpdate.GenreId = item.GenreId;
            itemToUpdate.IsAgeLimiting = item.IsAgeLimiting;
            itemToUpdate.Name = item.Name;
            itemToUpdate.Rating = item.Rating;

            base._context.Entry(itemToUpdate).State = EntityState.Modified;
        }

        IQueryable<Picture> IPictureRepository.GetAll()
        {
            return base.GetAll().Map<IQueryable<PictureEntity>, IQueryable<Picture>>();
        }
    }
}
