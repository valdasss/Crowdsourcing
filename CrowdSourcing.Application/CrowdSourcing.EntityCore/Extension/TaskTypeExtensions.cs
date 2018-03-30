using CrowdSourcing.Contract.Model;
using CrowdSourcing.EntityCore.Entity;

namespace CrowdSourcing.EntityCore.Extension
{
    public static class TaskTypeExtensions
    {
        public static TaskTypeModel ToModel(this TaskTypeEntity entity)
        {
            var model = new TaskTypeModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return model;
        }
        public static TaskTypeEntity ToEntity(this TaskTypeModel model)
        {
            var entity = new TaskTypeEntity()
            {
                Name = model.Name
            };
            return entity;
        }
    }
}
