using System;

namespace DataAcces.Entities
{
    public class UserExternalLoginEntity : IEntity
    {
        public Guid Id { get; set; }
        public Guid ExternalLoginId { get; set; }
        public Guid UserId { get; set; }
    }
}
