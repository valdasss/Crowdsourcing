using CrowdSourcing.EntityCore.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    class FileTypeConfiguration : EntityTypeConfiguration<FileTypeEntity>
    {
        public FileTypeConfiguration()
        {
            ToTable("FileTypes");

            HasKey(f=>f.Id);

            Property(f => f.Name)
                .IsRequired();
        }
    }
}
