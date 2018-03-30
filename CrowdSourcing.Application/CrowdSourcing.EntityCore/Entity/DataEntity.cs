using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Entity
{
    public class DataEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Description{ get; set; }
        public int IsDone { get; set; }
    }
}
