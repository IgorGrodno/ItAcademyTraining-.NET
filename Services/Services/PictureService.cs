using DataAcces;
using Domain.DTO;
using Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PictureService : IPictureService
    {
        private readonly IUnitOfWorkFactory _factory;

        public PictureService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public async Task Add(Picture picture)
        {
            using (var unitOfWork = _factory.Create())
            {
                unitOfWork.Pictures.Add(picture);
                await unitOfWork.Commit();
            }
        }

        public async Task ChangeRating(Picture picture, Guid? userId, bool isRatingIncressed, string ipAdress)
        {
            using (var unitOfWork = _factory.Create())
            {
                var ratingChangeEvent = await unitOfWork.GetRatingChangeEvents.GetByRatedItemAndIP(picture.Id, ipAdress);

                if (ratingChangeEvent == null)
                {
                    unitOfWork.GetRatingChangeEvents.Add(new RatingChangeEvent
                    {
                        Id = Guid.NewGuid(),
                        IpAdress = ipAdress,
                        IsRatingIncreased = isRatingIncressed,
                        ItemToRatingChangeId = picture.Id
                    });
                    await unitOfWork.Commit();
                    if (isRatingIncressed)
                    {
                        picture.Rating++;
                        await this.Update(picture);
                    }
                    else
                    {
                        picture.Rating--;
                        await this.Update(picture);
                    }
                }
                else
                {
                    await unitOfWork.GetRatingChangeEvents.DeleteById(ratingChangeEvent.Id);

                    if (ratingChangeEvent.IsRatingIncreased)
                    {
                        picture.Rating--;
                        await this.Update(picture);
                    }
                    else
                    {
                        picture.Rating++;
                        await this.Update(picture);
                    }
                }
                await unitOfWork.Commit();
            }
        }

        public async Task<List<Picture>> PageAll(int skip, int take)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Pictures.PageAll(skip, take);
            }
        }

        public async Task DeleteById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Pictures.DeleteById(id);
                await unitOfWork.Commit();
            }
        }



        public async Task<List<Picture>> PageByGenre(int skip, int take, Guid genreId)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Pictures.PageByGenreId(skip, take, genreId);
            }
        }

        public async Task<Picture> GetById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Pictures.GetById(id);
            }
        }



        public async Task Update(Picture picture)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Pictures.Update(picture);
                await unitOfWork.Commit();
            }
        }

        public IQueryable<Picture> GetAll()
        {
            using (var unitOfWork = _factory.Create())
            {
                return unitOfWork.Pictures.GetAll();
            }
        }
    }
}
