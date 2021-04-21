using DataAcces;
using Domain.DTO;
using Services.ServiceInterfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWorkFactory _factory;

        public GenreService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public async Task Add(Genre genre)
        {
            using (var unitOfWork = _factory.Create())
            {
                unitOfWork.Genres.Add(new Genre
                {
                    Id = genre.Id,
                    Description = genre.Description,
                    Name = genre.Name
                });

                await unitOfWork.Commit();
            }
        }

        public async Task DeleteById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Genres.DeleteById(id);
                await unitOfWork.Commit();
            }
        }

        public IQueryable<Genre> GetAll()
        {
            using (var unitOfWork = _factory.Create())
            {
                return unitOfWork.Genres.GetAll();
            }
        }

        public async Task<Genre> GetById(Guid id)
        {
            using (var unitOfWork = _factory.Create())
            {
                return await unitOfWork.Genres.GetById(id);
            }
        }

        public async Task Update(Genre item)
        {
            using (var unitOfWork = _factory.Create())
            {
                await unitOfWork.Genres.Update(item);
                await unitOfWork.Commit();
            }
        }

    }
}
