using DataAcces.Entities;
using DataAcces.Repositories;
using DataAcces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.Reposytories
{
    public class UserClaimRepository : Repository<UserClaimEntity>, IUserClaimRepository
    {
        public UserClaimRepository(DataContext context) : base(context)
        {
        }

        public async Task Add(Guid userId, Guid claimId)
        {
            base._dbSet.Add(new UserClaimEntity
            {
                Id = Guid.NewGuid(),
                ClaimId = claimId,
                UserId = userId
            });
        }

        public async Task Delete(Guid userId, Guid claimId)
        {
            base.Delete(base.GetByPredicate(x => x.ClaimId == claimId && x.UserId == userId).FirstOrDefault());
        }

        public async Task<IEnumerable<Guid>> GetClaimsId(Guid userId)
        {
            List<Guid> result = new List<Guid>();
            foreach (var item in base.GetByPredicate(x => x.UserId == userId))
            {
                result.Add(item.ClaimId);
            }
            return result;
        }
    }
}
