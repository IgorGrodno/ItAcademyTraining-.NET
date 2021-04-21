using System;
using System.Collections.Generic;

namespace DataAcces.Entities
{
    public class GenreEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PictureEntity> Pictures { get; set; }
    }
}
