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
    public class GenreRepository : Repository<GenreEntity>, IGenreRepository
    {
        public GenreRepository(DataContext context) : base(context)
        {
        }

        public void Add(Genre item)
        {
            base._dbSet.Add(item.Map<Genre, GenreEntity>());
        }



        public async Task<Genre> GetById(Guid id)
        {
            var result = await base._dbSet.FindAsync(id);
            return result.Map<GenreEntity, Genre>();
        }       

        public async Task Update(Genre item)
        {
            var itemToUpdate = await base._dbSet.FindAsync(item.Id);

            itemToUpdate.Name = item.Name;
            itemToUpdate.Description = item.Description;

            base._context.Entry(itemToUpdate).State = EntityState.Modified;
        }

        IQueryable<Genre> IGenreRepository.GetAll()
        {
            return base.GetAll().Map<IQueryable<GenreEntity>, IQueryable<Genre>>();
        }
    }
}
