using CrowdSourcing.Contract.Model.DataModels;
using CrowdSourcing.EntityCore.Entity;

namespace CrowdSourcing.EntityCore.Extension
{
    public static class DataExtensions
    {
        public static DataModel ToModel(this DataEntity entity)
        {
            var model = new DataModel()
            {
                Id = entity.Id,
                Description = entity.Description,
                Status = entity.Status,
                PersonId = entity.PersonId,
                UploadTime=entity.UploadTime
            };
            return model;
        }
    }
}
