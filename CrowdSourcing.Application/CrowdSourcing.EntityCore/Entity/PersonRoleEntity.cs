using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace CrowdSourcing.EntityCore.Entity
{
    public class PersonRoleEntity : IdentityUserRole
    {
        public ICollection<DataEntity> Datas { get; set; }
        public ICollection<SolutionEntity> Solutions { get; set; }
        public ICollection<SolutionEntity> Reviews { get; set; }
    }
}
