using CrowdSourcing.Contract.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleModel>> GetAllRolesAsync();
        Task<RoleModel> AddRoleAsync(string roleName);
        Task<RoleModel> UpdateRoleAsync(RoleModel roleModel);
        Task<RoleModel> GetRoleBy(string roleId);
        Task DeleteRoleAsync(string id);
    }
}
