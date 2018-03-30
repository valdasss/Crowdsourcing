using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public int TaskTypeId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } 
    }
}
