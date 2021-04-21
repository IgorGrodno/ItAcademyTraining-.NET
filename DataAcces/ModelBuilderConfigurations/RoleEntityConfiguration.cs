using DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.ModelBuilderConfigurations
{
    public class RoleEntityConfiguration : EntityTypeConfiguration<RoleEntity>
    {
        public RoleEntityConfiguration()
        {
            this.ToTable("Role");
            this.HasKey(x => x.Id);

            this.Property(x => x.Name).IsRequired();

            
        }
    }
}
