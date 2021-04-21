using DataAcces.Entities;
using DataAcces.RepositoryInterfaces;
using Domain.DTO;
using ExpressMapper.Extensions;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    public class RoleRepository : Repository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }

        public void Add(Role item)
        {
            base._dbSet.Add(item.Map<Role, RoleEntity>());
        }

        public async Task<Role> GetById(Guid id)
        {
            var result = await base._dbSet.FindAsync(id);
            return result.Map<RoleEntity, Role>();
        }

        public async Task<Role> GetByName(string name)
        {
            var result =  base.GetByPredicate(x=>x.Name==name).FirstOrDefault();           
            return result.Map<RoleEntity, Role>();
        }

        public async Task Update(Role item)
        {
            var itemToUpdate = await base._dbSet.FindAsync(item.Id);

            itemToUpdate.Name = item.Name;
            base._context.Entry(itemToUpdate).State = EntityState.Modified;
        }
    }
}
