using DataAcces.Entities;
using DataAcces.Repositories;
using DataAcces.RepositoryInterfaces;
using Domain.DTO;
using ExpressMapper.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataAcces.Reposytories
{
    public class UserSetingRepository : Repository<UserSettingsEntity>, IUserSetingsRepository
    {
        public UserSetingRepository(DataContext context) : base(context)
        {
        }

        public void Add(UserSeting item)
        {
            base._dbSet.Add(item.Map<UserSeting,UserSettingsEntity>());
        }

        public async Task<UserSeting> GetById(Guid id)
        {
            var result = await base._dbSet.FindAsync(id);
            return result.Map<UserSettingsEntity,UserSeting>();
        }

        public  IEnumerable<UserSeting> GetByUserId(Guid userId)
        {
           var result = base.GetByPredicate(x => x.UserId == userId);
            return result.Map<IEnumerable<UserSettingsEntity>,IEnumerable<UserSeting>>();
        }

        public async Task Update(UserSeting item)
        {
            var itemToUpdate = await base._dbSet.FindAsync(item.Id);
            itemToUpdate.PictureCount = item.PictureCount;
            base._context.Entry(itemToUpdate).State = EntityState.Modified;
        }
    }
}
