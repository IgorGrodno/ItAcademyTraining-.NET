using System;

namespace Domain.DTO
{
    public class ExternalLogin
    {
        public Guid Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public Guid UserId { get; set; }
    }
}
