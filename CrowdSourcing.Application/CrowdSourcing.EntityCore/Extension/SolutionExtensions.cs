using CrowdSourcing.Contract.Model.SolutionModels;
using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Extension
{
    public static class SolutionExtensions
    {
        public static AddSolutionModel ToAddModel(this SolutionEntity entity)
        {
            var model = new AddSolutionModel()
            {
                Id = entity.Id,
                AdminId = entity.AdminId,
                ExpertId = entity.ExpertId,
                TaskDataId = entity.TaskDataId,
                Status = entity.Status
            };
            return model;
        }
    }
}
