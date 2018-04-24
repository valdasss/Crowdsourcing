using CrowdSourcing.Contract.Model;
using CrowdSourcing.Contract.Model.Taskmodels;
using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Extension
{
    public static class TaskExtensions
    {
        public static UpdateTaskModel ToFullModel(this TaskEntity entity)
        {
            var model = new UpdateTaskModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                 Description= entity.Description,
                Status = entity.Status,
                TaskTypeId = entity.TaskTypeId
            };
            return model;
        }
        public static TaskModel ToModel (this TaskEntity entity )
        {
            var model = new TaskModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.Status,
                TaskType = entity.TaskType.Name
            };
            return model;
        }
       
    }
}
