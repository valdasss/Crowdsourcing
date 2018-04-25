using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Context;
using CrowdSourcing.Repository.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.UserManagment
{
    public class RoleRepository : IRoleRepository
    {
        private RoleManager<IdentityRole> _roleManager;

        public RoleRepository()
        {
            _roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new CrowdSourcingContext()));
        }
        public async  Task<IdentityRole> GetRoleByStringId(string id)
        {

            return await _roleManager.FindByIdAsync(id);      
        }

        public async Task DeleteRoleByStringID(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
        }

        public async Task<IdentityRole> AddRoleAsync(string name)
        {           
                var role = new IdentityRole() { Name = name };
                await  _roleManager.CreateAsync(role);
                return role;
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole> UpdateRole(IdentityRole role)
        {
            await _roleManager.UpdateAsync(role);
            return role;
        }

        public async Task<IdentityRole> GetRoleByName(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }
    }
}
