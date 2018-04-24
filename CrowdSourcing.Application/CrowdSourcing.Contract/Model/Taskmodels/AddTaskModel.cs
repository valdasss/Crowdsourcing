using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Model.Taskmodels
{
    public class AddTaskModel
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public int TaskTypeId { get; set; }
    }
}
