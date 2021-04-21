using DataAcces.Entities;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.RepositoryInterfaces
{
   public interface IUserSetingsRepository:IRepository<UserSettingsEntity>
    {
        Task<UserSeting> GetById(Guid id);
        void Add(UserSeting item);
        Task Update(UserSeting item);
        IEnumerable <UserSeting> GetByUserId(Guid userId);
    }
}
