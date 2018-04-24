using System.Collections.Generic;

namespace CrowdSourcing.EntityCore.Entity
{
    public class TaskTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
