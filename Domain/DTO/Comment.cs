using System;

namespace Domain.DTO
{
    public class Comment : IDTO
    {
        public Guid Id { get; set; }
        public string TextOfComment { get; set; }
        public Guid UserId { get; set; }
        public Guid PictureId { get; set; }
        public DateTime AddingDate { get; set; }
    }
}
