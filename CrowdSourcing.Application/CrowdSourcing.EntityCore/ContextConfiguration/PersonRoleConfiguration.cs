using CrowdSourcing.EntityCore.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class PersonRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public PersonRoleConfiguration()
        {
            ToTable("PersonRole");

            HasKey(p => p.UserId)
           .HasKey(p => p.RoleId);
          

        }
    }
}
