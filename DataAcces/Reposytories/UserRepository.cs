using DataAcces.Entities;
using DataAcces.RepositoryInterfaces;
using Domain.DTO;
using ExpressMapper;
using ExpressMapper.Extensions;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
           Mapper.Register<UserEntity, User>().Member(dest => dest.UserName,src => src.Name);
           Mapper.Register<User, UserEntity>().Member(dest => dest.Name, src => src.UserName);
        }

        public void Add(User item)
        {
            base._dbSet.Add(item.Map<User, UserEntity>());
        }

        public async Task<User> GetByName(string name)
        {
            return base.GetByPredicate(x => x.Name == name).FirstOrDefault().Map<UserEntity, User>();
        }

        public async Task<User> GetById(Guid id)
        {
            var result = await base._dbSet.FindAsync(id);
            return result.Map<UserEntity, User>();
        }

        public async Task Update(User item)
        {
            var itemToUpdate = await base._dbSet.FindAsync(item.Id);
            itemToUpdate.Id = item.Id;
            itemToUpdate.IsBlocked = item.IsBlocked;
            itemToUpdate.Name = item.UserName;
            itemToUpdate.PasswordHash = item.PasswordHash;
            itemToUpdate.SecurityStamp = item.SecurityStamp;
            base._context.Entry(itemToUpdate).State = EntityState.Modified;
        }

        IQueryable<User> IUserRepository.GetAll()
        {
            return base.GetAll().Map<IQueryable<UserEntity>, IQueryable<User>>();
        }
    }
}
