using System;

namespace Domain.DTO
{
    public class User : IDTO
    {
        public Guid Id { get; set; }
        public bool IsBlocked { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
    }
}
