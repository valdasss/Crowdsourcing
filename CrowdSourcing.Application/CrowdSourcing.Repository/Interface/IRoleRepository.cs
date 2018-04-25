using CrowdSourcing.EntityCore.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.Interface
{
    public interface IRoleRepository
    {
        Task<IdentityRole> GetRoleByStringId(string id);
        Task<IdentityRole> GetRoleByName(string name);
        Task<IdentityRole> AddRoleAsync(string name);
        Task<IEnumerable<IdentityRole>> GetAllRoles();       
        Task<IdentityRole> UpdateRole(IdentityRole role);
        Task DeleteRoleByStringID(string Id);
    }
}
