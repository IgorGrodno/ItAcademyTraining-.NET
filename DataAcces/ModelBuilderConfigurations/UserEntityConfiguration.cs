using DataAcces.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAcces.ModelBuilderConfigurations
{
    public class UserEntityConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserEntityConfiguration()
        {
            this.ToTable("User");
            this.HasKey(x => x.Id);
            
            this.Property(x => x.PasswordHash).IsOptional();
            this.Property(x => x.SecurityStamp).IsOptional();
            this.Property(x => x.Name).IsRequired();
              }
    }
}
