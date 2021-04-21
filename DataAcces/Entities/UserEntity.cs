using System;
using System.Collections.Generic;

namespace DataAcces.Entities
{
    public class UserEntity : IEntity
    {
        public Guid Id { get; set; }
        public bool IsBlocked { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        public ICollection<RatingChangeEventEntity> RatingChangeEvents { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<UserClaimEntity> Claims { get; set; }
        public ICollection<UserExternalLoginEntity> ExternalLogins { get; set; }
        public ICollection<UserRoleEntity> Roles { get; set; }
        public ICollection<UserSettingsEntity> Settings { get; set; }
    }
}

