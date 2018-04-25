using CrowdSourcing.Contract.Model.FileTypeModels;
using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Extension
{
    public static class FileTypeExtensions
    {
        public static FileTypeFullModel ToModel(this FileTypeEntity entity)
        {
            var model = new FileTypeFullModel()
            {
               Id = entity.Id,
               Name = entity.Name
            };
            return model;
        }
    }
}
