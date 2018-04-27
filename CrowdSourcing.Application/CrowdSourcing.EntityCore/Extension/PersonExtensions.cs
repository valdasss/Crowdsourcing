using CrowdSourcing.Contract.Model.PersonModel;
using CrowdSourcing.EntityCore.Entity;

namespace CrowdSourcing.EntityCore.Extension
{
    public static class PersonExtensions
    {
        public static PersonModel ToModel(this PersonEntity entity)
        {
            var model = new PersonModel()
            {
                Id = entity.Id,
                Name = entity.FirstName,
                Email = entity.Email,
                LastName= entity.LastName
            };
            return model;
        }
        public static PersonWithRoleModel ToModelWithRole(this PersonEntity entity,string role)
        {
            var model = new PersonWithRoleModel()
            {
                Id = entity.Id,
                Name = entity.FirstName,
                Email = entity.Email,
                LastName = entity.LastName,
                Role = role
            };
            return model;
        }
        public static PersonEntity ToEntity(this PersonModel model)
        {
            var entity = new PersonEntity()
            {
                FirstName=model.Name,
                LastName=model.LastName,
                Email=model.Email,
                UserName = model.Email,
            };
            return entity;
        }
    }
}
