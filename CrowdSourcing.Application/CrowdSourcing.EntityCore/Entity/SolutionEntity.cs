using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Entity
{
    public class SolutionEntity
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int ExpertId { get; set; }
        public int TaskDataId { get; set; }
        public int Status { get; set; }
        public DateTime SolutionDate { get; set; }
        public string Comment { get; set; }
    }
}
