using System;

namespace Domain.DTO
{
    public class Picture : IDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GenreId { get; set; }
        public DateTime AddingDate { get; set; }
        public int Rating { get; set; }
        public bool IsAgeLimiting { get; set; }
    }
}
