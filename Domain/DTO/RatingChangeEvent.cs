using System;

namespace Domain.DTO
{
    public class RatingChangeEvent : IDTO
    {
        public Guid Id { get; set; }
        public Guid ItemToRatingChangeId { get; set; }
        public string IpAdress { get; set; }
        public bool IsRatingIncreased { get; set; }
        public Guid? UserId { get; set; }
    }
}
