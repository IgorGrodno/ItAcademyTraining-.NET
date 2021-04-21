using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
    public interface IRatingChangeEventRepository : IRepository<RatingChangeEventEntity>
    {
        Task<RatingChangeEvent> GetById(Guid id);
        void Add(RatingChangeEvent item);
        Task<RatingChangeEvent> GetByRatedItemAndIP(Guid ratedItemId, string ipAdress);
    }
}
