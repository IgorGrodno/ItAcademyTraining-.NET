using DataAcces.Entities;
using DataAcces.Repositories;
using DataAcces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.Reposytories
{
    public class UserExternalLoginRepository : Repository<UserExternalLoginEntity>, IUserExternalLoginRepository
    {
        public UserExternalLoginRepository(DataContext context) : base(context)
        {
        }

        public async Task Add(Guid userId, Guid externalLoginId)
        {
            base._dbSet.Add(new UserExternalLoginEntity
            {
                Id = Guid.NewGuid(),
                ExternalLoginId = externalLoginId,
                UserId = userId
            });
        }

        public async Task Delete(Guid userId, Guid externalLoginId)
        {
            base.Delete(base.GetByPredicate(x => x.ExternalLoginId == externalLoginId && x.UserId == userId).FirstOrDefault());
        }

        public async Task<IEnumerable<Guid>> GetLoginsId(Guid userId)
        {
            List<Guid> result = new List<Guid>();
            foreach (var item in base.GetByPredicate(x => x.UserId == userId))
            {
                result.Add(item.ExternalLoginId);
            }
            return result;
        }

        public async Task<Guid> GetUserId(Guid loginId)
        {
            return base.GetByPredicate(x => x.ExternalLoginId == loginId).FirstOrDefault().UserId;

        }
    }
}
