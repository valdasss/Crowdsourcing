using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Entity
{
    public class TaskDataEntity
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int DataId { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
