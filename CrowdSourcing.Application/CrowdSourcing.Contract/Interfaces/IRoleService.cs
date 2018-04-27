using CrowdSourcing.Contract.Model.PersonModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleModel>> GetAllRolesAsync();
        Task<IEnumerable<PersonModel>> GetExperts(string name);
        Task<RoleModel> GetRoleByName(string name);
        Task<RoleModel> AddRoleAsync(string roleName);
        Task<RoleModel> UpdateRoleAsync(RoleModel roleModel);
        Task<RoleModel> GetRoleBy(string roleId);
        Task DeleteRoleAsync(string id);
    }
}
