using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Entity
{
    public class PersonRoleEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
    }
}
