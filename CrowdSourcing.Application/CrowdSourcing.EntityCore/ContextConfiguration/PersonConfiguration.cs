using CrowdSourcing.EntityCore.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class PersonConfiguration : EntityTypeConfiguration<PersonEntity>
    {
        public PersonConfiguration()
        {
            ToTable("Persons");

            HasKey(p => p.Id);

            Property(p => p.FirstName)
                .IsRequired();

            Property(p => p.LastName)
                .IsRequired();

            Property(p => p.Password)
                .IsRequired();

            Property(p => p.E_mail)
                .IsRequired();
        }
    }
}
