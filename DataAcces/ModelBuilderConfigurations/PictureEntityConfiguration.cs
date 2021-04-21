using DataAcces.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAcces.ModelBuilderConfigurations
{
    public class PictureEntityConfiguration: EntityTypeConfiguration<PictureEntity>
    {
        public PictureEntityConfiguration()
        {
            this.ToTable("Pictures");
            this.HasKey(x => x.Id);
            this.Property(Picture => Picture.Name).IsRequired().IsUnicode(true);
            this.Property(Picture => Picture.AddingDate).IsRequired();
            this.HasMany(Picture => Picture.Comments).WithRequired(Comment => Comment.Picture);           
        }
    }
}
