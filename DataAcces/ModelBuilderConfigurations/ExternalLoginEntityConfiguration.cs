using DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.ModelBuilderConfigurations
{
    public class ExternalLoginEntityConfiguration : EntityTypeConfiguration<ExternalLoginEntity>
    {
        public ExternalLoginEntityConfiguration()
        {
            this.ToTable("ExternalLogin");
            this.HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });
            this.Property(x => x.LoginProvider).IsRequired();
            this.Property(x => x.ProviderKey).IsRequired();
            this.Property(x => x.UserId).IsRequired();
            
        }
    }
}
