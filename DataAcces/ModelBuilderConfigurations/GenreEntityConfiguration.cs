using DataAcces.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAcces.ModelBuilderConfigurations
{
    public class GenreEntityConfiguration: EntityTypeConfiguration<GenreEntity>
    {
        public GenreEntityConfiguration()
        {
            this.ToTable("Genres");
            this.HasKey(x => x.Id);
            this.Property(Genre => Genre.Name).IsRequired().IsUnicode(true);
            this.Property(Genre => Genre.Description).IsUnicode(true);
            this.HasMany(Genre => Genre.Pictures).WithRequired(Picture => Picture.Genre);
        }
    }
}
