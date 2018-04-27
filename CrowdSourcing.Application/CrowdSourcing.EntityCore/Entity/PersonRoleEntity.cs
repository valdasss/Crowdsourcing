using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace CrowdSourcing.EntityCore.Entity
{
    public class PersonRoleEntity : IdentityUserRole
    {
        public PersonEntity Person { get; set; }
        public IdentityRole Role { get; set; }
        public ICollection<DataEntity> Datas { get; set; }
        public ICollection<SolutionEntity> Solutions { get; set; }
        public ICollection<SolutionEntity> Reviews { get; set; }
    }
}
