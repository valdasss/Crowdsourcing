using System.Collections.Generic;

namespace CrowdSourcing.EntityCore.Entity
{
    public class FileTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FileEntity> Files { get; set; }
    }
}
