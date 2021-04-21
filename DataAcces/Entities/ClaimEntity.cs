using System;
using System.Collections.Generic;

namespace DataAcces.Entities
{
    public class ClaimEntity : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }

        public ICollection<UserClaimEntity> UserClaims { get; set; }
    }
}
