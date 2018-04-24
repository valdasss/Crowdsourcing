using CrowdSourcing.EntityCore.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class FileTypeConfiguration : EntityTypeConfiguration<FileTypeEntity>
    {
        public FileTypeConfiguration()
        {
            ToTable("FileType");

            HasKey(f=>f.Id);

            Property(f => f.Name)
                .IsRequired();
        }
    }
}
