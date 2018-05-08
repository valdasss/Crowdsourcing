using CrowdSourcing.EntityCore.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class DataConfiguration : EntityTypeConfiguration<DataEntity>
    {
        public DataConfiguration()
        {
            ToTable("Data");

            HasKey(d => d.Id);

            Property(d => d.Description)
                .IsOptional();

            Property(d => d.PersonRoleId)
               .IsRequired();

            Property(d => d.PersonId)
                .IsRequired();

            Property(d => d.Status)
                .IsRequired();

            Property(d => d.UploadTime)
                .IsRequired();

            HasRequired(t => t.Uploader)
                .WithMany()
                .HasForeignKey(t => new { t.PersonId,t.PersonRoleId }).WillCascadeOnDelete(false);
        }
    }
}
