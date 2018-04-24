using CrowdSourcing.Contract.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Extension
{
    public static class RoleExtensions
    {
        public static RoleModel ToModel(this IdentityRole entity)
        {
            var model = new RoleModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return model;
        }
        public static IdentityRole ToEntity(this RoleModel model)
        {
            var entity = new IdentityRole()
            {
                Name = model.Name
            };
            return entity;
        }
    }

}
