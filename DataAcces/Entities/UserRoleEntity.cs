using System;

namespace DataAcces.Entities
{
    public class UserRoleEntity : IEntity
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
