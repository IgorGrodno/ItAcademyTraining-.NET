using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IGenreRepository : IRepository<GenreEntity>
    {
        Task<Genre> GetById(Guid id);
        void Add(Genre item);
        Task Update(Genre item);
        new IQueryable<Genre> GetAll();
    }
}
