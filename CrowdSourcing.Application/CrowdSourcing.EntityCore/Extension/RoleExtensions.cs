using CrowdSourcing.Contract.Model.PersonModel;
using Microsoft.AspNet.Identity.EntityFramework;

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
