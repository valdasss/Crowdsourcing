using CrowdSourcing.Application.Web.ViewModels;
using CrowdSourcing.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSourcing.Application.Web.Extension
{
    public static class PersonExtensions
    {
        public static UserVM ToViewModel(this PersonWithRoleModel model)
        {
            var viewModel = new UserVM
            {
                Id = model.Id,
                FirstName = model.Name,
                Email = model.Email,
                LastName = model.LastName,
                Role = model.Role
            };
            return viewModel;

        }
        public static PersonModel ToModel(this AccountVM viewModel)
        {
            var model = new PersonModel
            {
                Name = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email
            };
            return model;
        }
        public static PersonCRUDVM ToAcoountVm(this PersonModel model)
        {
            var modelVm = new PersonCRUDVM
            {
                Id=model.Id,
                FirstName = model.Name,
                LastName = model.LastName,
                Email = model.Email
            };
            return modelVm;
        }
    }
}