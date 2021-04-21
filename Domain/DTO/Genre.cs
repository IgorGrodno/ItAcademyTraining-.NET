using System;

namespace Domain.DTO
{
    public class Genre : IDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
