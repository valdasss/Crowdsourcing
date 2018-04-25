using CrowdSourcing.Application.Web.ViewModels;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.EntityCore.Context;
using CrowdSourcing.EntityCore.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CrowdSourcing.Application.Web.Controllers
{
    [RoutePrefix("Role")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IHttpActionResult> AddRole(AddNameVM roleName)
        {
            var addedRole= await _roleService.AddRoleAsync(roleName.Name);
            return Ok(addedRole);
        }

    }
}
