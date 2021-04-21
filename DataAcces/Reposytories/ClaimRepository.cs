using DataAcces.Entities;
using DataAcces.RepositoryInterfaces;
using Domain.DTO;
using ExpressMapper.Extensions;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    public class ClaimRepository : Repository<ClaimEntity>, IClaimRepository
    {
        public ClaimRepository(DataContext context) : base(context)
        {

        }

        public void Add(Claim item)
        {
            base._dbSet.Add(item.Map<Claim, ClaimEntity>());
        }

        public async Task<Claim> GetById(Guid id)
        {
            var result = await base._dbSet.FindAsync(id);
            return result.Map<ClaimEntity, Claim>();
        }

        public async Task Update(Claim item)
        {
            var itemToUpdate = await base._dbSet.FindAsync(item.Id);

            itemToUpdate.ClaimType = item.ClaimType;
            itemToUpdate.ClaimValue = item.ClaimValue;

            base._context.Entry(itemToUpdate).State = EntityState.Modified;
        }
    }
}
