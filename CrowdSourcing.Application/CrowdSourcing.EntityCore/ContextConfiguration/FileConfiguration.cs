using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class FileConfiguration : EntityTypeConfiguration<FileEntity>
    {
        public FileConfiguration()
        {
            ToTable("File");

            HasKey(f => f.Id);

            Property(f => f.DataId)
                .IsRequired();

            Property(f => f.FileTypeId)
                .IsRequired();

            Property(f => f.Url)
                .IsRequired();

            HasRequired(f => f.Data)
                .WithMany(d => d.Files);

            HasRequired(f => f.FileType)
               .WithMany(ft => ft.Files);
        }
    }
}
