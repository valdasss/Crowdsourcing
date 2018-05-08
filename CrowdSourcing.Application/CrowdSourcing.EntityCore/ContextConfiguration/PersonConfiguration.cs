using CrowdSourcing.EntityCore.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    internal class PersonConfiguration : EntityTypeConfiguration<PersonEntity>
    {
        public PersonConfiguration()
        {
            ToTable("Person");
           
            HasKey(p => p.Id);

            Property(p => p.FirstName)
                .IsRequired();

            Property(p => p.LastName)
                .IsRequired();

            Property(p => p.PasswordHash)
                .IsRequired();

            Property(p => p.Email)
                .IsRequired();

            HasMany(p => p.Roles).WithRequired().HasForeignKey(p => p.UserId).WillCascadeOnDelete(true);
        }
    }
}
