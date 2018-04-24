using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class LoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public LoginConfiguration()
        {
            ToTable("Login");

            HasKey(l => l.UserId);

        }
    }
}
