using System;
using System.Linq;
using System.Threading.Tasks;
using DataAcces.Entities;
using DataAcces.RepositoryInterfaces;
using Domain.DTO;
using ExpressMapper.Extensions;

namespace DataAcces.Repositories
{
    public class RatingChangeEventRepository : Repository<RatingChangeEventEntity>, IRatingChangeEventRepository
    {
        public RatingChangeEventRepository(DataContext context) : base(context)
        {
        }

        public void Add(RatingChangeEvent item)
        {
            base._dbSet.Add(item.Map<RatingChangeEvent, RatingChangeEventEntity>());
        }

        public async Task<RatingChangeEvent> GetById(Guid id)
        {
            var result = await base._dbSet.FindAsync(id);
            return result.Map<RatingChangeEventEntity, RatingChangeEvent>();
        }

        public async Task<RatingChangeEvent> GetByRatedItemAndIP(Guid ratedItemId, string ipAdress)
        {
            var resultList = base.GetByPredicate(x => x.ItemToRatingChangeId == ratedItemId && x.IpAdress == ipAdress);
            return resultList.FirstOrDefault().Map<RatingChangeEventEntity, RatingChangeEvent>();
        }
    }
}
