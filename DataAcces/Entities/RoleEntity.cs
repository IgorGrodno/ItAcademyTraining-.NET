using System;
using System.Collections.Generic;

namespace DataAcces.Entities
{
    public class RoleEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRoleEntity> Users { get; set; }
    }
}
