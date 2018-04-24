using System.Collections.Generic;

namespace CrowdSourcing.EntityCore.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public int TaskTypeId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } 

        public TaskTypeEntity TaskType { get; set; }
        public ICollection<TaskDataEntity> TaskDatas { get; set; }
    }
}
