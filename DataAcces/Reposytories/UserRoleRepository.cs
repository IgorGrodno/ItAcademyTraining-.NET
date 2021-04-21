using DataAcces.Entities;
using DataAcces.Repositories;
using DataAcces.RepositoryInterfaces;
using Domain.DTO;
using ExpressMapper.Extensions;
using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces.Reposytories
{
    public class UserRoleRepository : Repository<UserRoleEntity>, IUserRoleRepository
    {
        public UserRoleRepository(DataContext context) : base(context)
        {
        }

        public async Task Add(Guid userId, Guid roleId)
        {
            base._dbSet.Add(new UserRoleEntity
            {
                Id = Guid.NewGuid(),
                RoleId = roleId,
                UserId = userId
            });
        }

        public async Task Delete(Guid userId, Guid roleId)
        {
            base.Delete(base.GetByPredicate(x => x.RoleId == roleId && x.UserId == userId).FirstOrDefault());
        }

        public async Task<Guid> GetRoleIdByUserId(Guid userId)
        {
            var result = base.GetByPredicate(x => x.UserId == userId).FirstOrDefault();
            return result.RoleId;
        }
    }
}

