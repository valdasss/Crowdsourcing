using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Model.TaskDataModel
{
    public class TaskDataWithTaskModel
    {
        public DateTime? FinishDate { get; set; }
        public string Name { get; set; }
        public string TaskType { get; set; }
        public string Description { get; set; }
    }
}
