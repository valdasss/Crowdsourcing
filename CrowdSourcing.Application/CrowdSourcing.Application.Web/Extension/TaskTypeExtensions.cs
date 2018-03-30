using CrowdSourcing.Application.Web.ViewModels;
using CrowdSourcing.Contract.Model;

namespace CrowdSourcing.Application.Web.Extension
{
    public static class TaskTypeExtensions
    {
        public static TaskTypeViewModel ToViewModel (this TaskTypeModel model)
        {
            var viewModel = new TaskTypeViewModel
            {
                Id = model.Id,
                Name = model.Name
            };
            return viewModel;

        }
        public static TaskTypeModel ToModel(this TaskTypeViewModel viewModel)
        {
            var model = new TaskTypeModel
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };
            return model;
        }
    }
}