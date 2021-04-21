using DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.ModelBuilderConfigurations
{
    public class ClaimEntityConfiguration : EntityTypeConfiguration<ClaimEntity>
    {
        public ClaimEntityConfiguration()
        {
            this.ToTable("Claims");
            this.HasKey(x => x.Id);
}
    }
}
