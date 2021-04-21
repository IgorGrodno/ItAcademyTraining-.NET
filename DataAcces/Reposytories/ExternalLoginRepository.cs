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
    public class ExternalLoginRepository : Repository<ExternalLoginEntity>, IExternalLoginRepository
    {
        public ExternalLoginRepository(DataContext context) : base(context)
        {
        }

        public void Add(ExternalLogin item)
        {
            base._dbSet.Add(item.Map<ExternalLogin, ExternalLoginEntity>());
        }

        public async Task<ExternalLogin> GetById(Guid id)
        {
            var result = await base._dbSet.FindAsync(id);
            return result.Map<ExternalLoginEntity, ExternalLogin>();
        }

        public async Task<ExternalLogin> GetByProviderAndKey(string loginProvider, string providerKey)
        {
            var result = base.GetByPredicate(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey).FirstOrDefault();
            return result.Map<ExternalLoginEntity, ExternalLogin>();
        }

        public async Task Update(ExternalLogin item)
        {
            var itemToUpdate = await base._dbSet.FindAsync(item.Id);

            itemToUpdate.ProviderKey = item.ProviderKey;
            itemToUpdate.LoginProvider = item.LoginProvider;

            base._context.Entry(itemToUpdate).State = EntityState.Modified;
        }
    }
}
