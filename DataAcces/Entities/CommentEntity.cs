using System;
using System.Collections.Generic;

namespace DataAcces.Entities
{
    public class CommentEntity : IEntity
    {
        public Guid Id { get; set; }
        public string TextOfComment { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid PictureId { get; set; }
        public PictureEntity Picture { get; set; }
        public DateTime AddingDate { get; set; }

        public ICollection<RatingChangeEventEntity> RatingChangeEvents { get; set; }
    }
}
