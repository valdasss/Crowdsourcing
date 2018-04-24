using Microsoft.AspNet.Identity.EntityFramework;

namespace CrowdSourcing.EntityCore.Entity
{
    public class PersonEntity: IdentityUser
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
   
    }
}
