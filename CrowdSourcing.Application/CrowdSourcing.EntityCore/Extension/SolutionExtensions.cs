using CrowdSourcing.Contract.Model.DataModels;
using CrowdSourcing.Contract.Model.PersonModel;
using CrowdSourcing.Contract.Model.SolutionModels;
using CrowdSourcing.Contract.Model.TaskDataModel;
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
        public static SolutionEntity ToEntityModel(string expertId,string expertRoleId,string adminId,string adminRoleId,int taskDataId)
        {
            var model = new SolutionEntity()
            {
                ExpertId = expertId,
                ExpertRoleId = expertRoleId,
                SolutionDate = DateTime.Now,
                Status = 1,
                TaskDataId = taskDataId,
                AdminRoleId = adminRoleId,
                AdminId =adminId
            };
            return model;
        }
        public static SolutionEntity ToEntityModel(string expertId, string expertRoleId, string adminId, string adminRoleId, int taskDataId,int solutionId)
        {
            var model = new SolutionEntity()
            {
                ExpertId = expertId,
                ExpertRoleId = expertRoleId,
                SolutionDate = DateTime.Now,
                Status = 1,
                TaskDataId = taskDataId,
                AdminRoleId = adminId,
                AdminId = adminRoleId,
                SolutionReviewId = solutionId
            };
            return model;
        }

        public static SolutionInfoModel ToSolutionInfoModel(this SolutionEntity solution,
            PersonWithRoleModel admin, PersonWithRoleModel expert, DataForMoreDetails taskData)
        {
            var model = new SolutionInfoModel()
            {
                SolutionId = solution.Id,
                AssignDate = solution.SolutionDate,
                AssignerName = admin.Name,
                AssignerLastName = admin.LastName,
                ExpertsComment = solution.Comment,
                Status = solution.Status,
                UploadersComment = taskData.UploaderComment,
                Files = taskData.Files,
                DataId = taskData.DataId,
                Rating = solution.Rating,
                ExpertLastName = expert.LastName,
                ExpertName = expert.Name
            };
            return model;
        }
        public static DetailedSolutionModelForExpert ToDetailsSolutionModelForExpert(this SolutionEntity solution,
           PersonWithRoleModel admin, DataForMoreDetails taskData, TaskDataWithTaskModel taskDataWithTask)
        {
            var model = new DetailedSolutionModelForExpert()
            {
                SolutionId = solution.Id,
                AssignDate = solution.SolutionDate,
                AssignerName = admin.Name,
                AssignerLastName = admin.LastName,
                ExpertsComment = solution.Comment,
                Status = solution.Status,
                UploadersComment = taskData.UploaderComment,
                DataId = taskData.DataId,
                Files = taskData.Files,
                TaskName = taskDataWithTask.Name,
                TaskDescription = taskDataWithTask.Description,
                Rating = solution.Rating
            };
            return model;
        }
        public static SolutionShortInfoModel ToSolutionShortInfoModel(this SolutionEntity solution,
           PersonWithRoleModel admin, PersonWithRoleModel expert)
        {
            var model = new SolutionShortInfoModel()
            {
                SolutionId = solution.Id,
                AdminName = admin.Name,
                AdminLastName = admin.LastName,
                ExpertName = expert.Name,
                ExpertLastName = expert.LastName,
                SolutionCreationDate = solution.SolutionDate,
                Status = solution.Status,
                Rating = solution.Rating
            };
            return model;
        }
        public static SolutionModelForExpertSolutionList ToSolutionForExpertSolutionList(this SolutionEntity solution,
           PersonWithRoleModel admin, TaskDataWithTaskModel taskDataWithTask)
        {
            var model = new SolutionModelForExpertSolutionList()
            {
                SolutionId = solution.Id,
                AdminName = admin.Name,
                AdminLastName = admin.LastName,
                SolutionCreationDate = solution.SolutionDate,
                Status = solution.Status,
                TaskName = taskDataWithTask.Name,
                Rating = solution.Rating
            };
            return model;
        }
        public static SolutionModelForDoubleCheck ToSolutionModelForDoubleCheck(this SolutionEntity solution,
           PersonWithRoleModel expert, TaskDataWithTaskModel taskDataWithTask)
        {
            var model = new SolutionModelForDoubleCheck()
            {
                SolutionId = solution.Id,
                ExpertLastName = expert.LastName,
                ExpertName = expert.Name,
                LatestUpdateDate = taskDataWithTask.FinishDate
            };
            return model;
        }
    }
}
