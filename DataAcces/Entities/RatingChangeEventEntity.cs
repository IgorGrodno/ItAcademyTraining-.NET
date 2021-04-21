using System;

namespace DataAcces.Entities
{
    public class RatingChangeEventEntity : IEntity
    {
        public Guid Id { get; set; }
        public Guid ItemToRatingChangeId { get; set; }
        public IEntity ItemToRatingChange { get; set; }
        public string IpAdress { get; set; }
        public bool IsRatingIncreased { get; set; }
        public Guid? UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
