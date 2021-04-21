using System;

namespace DataAcces.Entities
{
    public class UserClaimEntity : IEntity
    {
        public Guid Id { get; set; }
        public Guid ClaimId { get; set; }
        public Guid UserId { get; set; }
    }
}
