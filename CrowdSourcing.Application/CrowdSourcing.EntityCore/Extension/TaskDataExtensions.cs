using CrowdSourcing.Contract.Model;
using CrowdSourcing.Contract.Model.DataModels;
using CrowdSourcing.Contract.Model.TaskDataModel;
using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Extension
{
    public static class TaskDataExtensions
    {
        public static TaskDataModel ToModel(this TaskDataEntity entity)
        {
            var model = new TaskDataModel()
            {
                Id = entity.Id,
                DataId = entity.DataId,
                TaskId = entity.TaskId,
                FinishDate = entity.FinishDate
            };
            return model;
        }
        public static TaskDataForTable ToTableModel(this TaskDataEntity entity,string FirstName,string LastName)
        {
            var model = new TaskDataForTable()
            {
                FirstName = FirstName,
                DataId = entity.DataId,
                LastName = LastName,
                Status = entity.Data.Status,
                UploadDate=entity.Data.UploadTime
            };
            return model;
        }
    }
}
