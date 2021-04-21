using System;
using System.Collections.Generic;

namespace DataAcces.Entities
{
    public class ExternalLoginEntity : IEntity
    {
        public Guid Id { get; set; }
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual Guid UserId { get; set; }

        public ICollection<UserExternalLoginEntity> Users { get; set; }
    }
}
