using CrowdSourcing.Contract.Model.PersonModel;
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
        public static SolutionModelForRating ToRatingModel(this SolutionEntity entity)
        {
            var model = new SolutionModelForRating()
            {
                SolutionId = entity.Id,
                Rating = entity.Rating
            };
            return model;
        }
        //public static SolutionEntity ToEntityModel(PersonWithRoleModel admin, PersonWithRoleModel expert, int taskDataId)
        //{
        //    var model = new SolutionEntity()
        //    {
        //        ExpertId= expert.Id,
        //        ExpertRoleId = e,
        //        SolutionDate = DateTime.Now,
        //        Status = 1,
        //        TaskDataId = ,
        //        AdminRoleId = ,
        //        AdminId = 
        //    };
        //    return model;
        //}
        //public static SolutionEntity ToEntityModel(PersonWithRoleModel admin, PersonWithRoleModel expert, int taskDataId,int solutionId)
        //{
        //    var model = new SolutionEntity()
        //    {
        //        ExpertId = ,
        //        ExpertRoleId = ,
        //        SolutionDate = DateTime.Now,
        //        Status = 1,
        //        TaskDataId = ,
        //        AdminRoleId = ,
        //        AdminId =,
        //        SolutionReviewId=solutionId
        //    };
        //    return model;
        //}
    }
}
