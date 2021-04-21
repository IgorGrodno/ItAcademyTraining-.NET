using DataAcces.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAcces.ModelBuilderConfigurations
{
    public class RatingChangrEventEntityConfiguration:EntityTypeConfiguration<RatingChangeEventEntity>
    {
        public RatingChangrEventEntityConfiguration()
        {
            this.ToTable("RatingChangeEvents");
            this.HasKey(x => x.Id);
            this.Property(RatingChangeEvent => RatingChangeEvent.IsRatingIncreased).IsRequired();
            this.Property(RatingChangeEvent => RatingChangeEvent.IpAdress).IsRequired();
            this.Property(RatingChangeEvent => RatingChangeEvent.ItemToRatingChangeId).IsRequired();
        }
    }
}
