using System;
using System.Collections.Generic;

namespace DataAcces.Entities
{
    public class PictureEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GenreId { get; set; }
        public GenreEntity Genre { get; set; }
        public DateTime AddingDate { get; set; }
        public int Rating { get; set; }
        public bool IsAgeLimiting { get; set; }

        public ICollection<RatingChangeEventEntity> RatingChangeEvents { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
    }
}
