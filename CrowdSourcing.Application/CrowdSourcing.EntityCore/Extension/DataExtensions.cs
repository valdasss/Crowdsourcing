using CrowdSourcing.Contract.Helpers;
using CrowdSourcing.Contract.Model.DataModels;
using CrowdSourcing.Contract.Model.FileModels;
using CrowdSourcing.EntityCore.Entity;
using System.Collections.Generic;

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
        
        public static DataForMoreDetails ToForDetailsModel(this DataEntity entity, string firstName,string lastName)
        {
            var model = new DataForMoreDetails()
            {
                DataId = entity.Id,
                FirstName = firstName,
                LastName = lastName,
                Status = entity.Status,
                UploadDate = entity.UploadTime,
                UploaderComment = entity.Description
                
            };
            var list = new List<FileForDetailsModel>();
            foreach (var item in entity.Files)
            {
                var file = new FileForDetailsModel()
                {
                    FileId = item.Id,
                    FileName = UrlParser.GetFileNameWithOutExtension(item.Url),
                    Format = item.FileType.Name

                };
                list.Add(file);
            }
            model.Files = list;
            return model;
        }
    }
}
