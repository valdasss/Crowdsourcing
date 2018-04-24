using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class RoleConfiguration : EntityTypeConfiguration<IdentityRole>
    {
        public RoleConfiguration()
        {
            ToTable("Role");

            HasKey(r => r.Id);

            Property(r => r.Name)
                .IsRequired();
        }
    }
}
