using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleModel> AddRoleAsync(string roleName)
        {
                   
            var role = await _roleRepository.AddRoleAsync(roleName);
            return role.ToModel();
        }

        public async Task DeleteRoleAsync(string id)
        {
            await _roleRepository.DeleteRoleByStringID(id);
        }

        public async Task<IEnumerable<RoleModel>> GetAllRolesAsync()
        {
           var roles= await _roleRepository.GetAllRoles();
            return roles.Select(r => r.ToModel());
        }

        public async Task<RoleModel> GetRoleBy(string roleId)
        {
            var role = await _roleRepository.GetRoleByStringId(roleId);
            return role.ToModel();
        }

        public async Task<RoleModel> UpdateRoleAsync(RoleModel roleModel)
        {
            var roleEntity = await _roleRepository.GetRoleByStringId(roleModel.Id);
            return roleEntity.ToModel();
        }
    }
}
