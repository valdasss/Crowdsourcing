using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class RoleConfiguration : EntityTypeConfiguration<RoleEntity>
    {
        public RoleConfiguration()
        {
            ToTable("Roles");

            HasKey(r => r.Id);

            Property(r => r.Name)
                .IsRequired();
        }
    }
}
