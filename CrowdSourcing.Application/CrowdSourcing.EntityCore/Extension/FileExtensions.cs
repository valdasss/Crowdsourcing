using CrowdSourcing.Contract.Model.FileModels;
using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Extension
{
    public static class FileExtensions
    {
        public static FileModel ToModel(this FileEntity entity)
        {
            var model = new FileModel()
            {
                Id = entity.Id,
                DataId = entity.DataId,
                FileTypeId = entity.FileTypeId,
                Url =entity.Url
            };
            return model;
        }
    }
}
