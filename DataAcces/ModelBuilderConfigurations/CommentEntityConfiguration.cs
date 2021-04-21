using DataAcces.Entities;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DataAcces.ModelBuilderConfigurations
{
    public class CommentEntityConfiguration : EntityTypeConfiguration<CommentEntity>
    {
        public CommentEntityConfiguration()
        {
            this.ToTable("Comments");
            this.HasKey(x => x.Id);
            this.Property(Comment => Comment.TextOfComment).IsRequired().IsUnicode(true);
            this.Property(Comment => Comment.AddingDate).HasColumnType("datetime2");
            this.HasRequired(Comment => Comment.Picture);
            this.HasMany(Comment => Comment.RatingChangeEvents);
        }
    }
}
