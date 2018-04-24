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

            Property(d => d.PersonId)
                .IsRequired();

            Property(d => d.IsDone)
                .IsRequired();

            HasRequired(t => t.Uploader)
                .WithMany()
                .HasForeignKey(t => t.PersonId);
        }
    }
}
