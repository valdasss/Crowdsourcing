using CrowdSourcing.Contract.Model;
using CrowdSourcing.Contract.Model.Taskmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetAllTasksWithTypeAsync();
        Task<TaskModel> AddTaskAsync(AddTaskModel taskModel);
        Task<TaskModel> UpdatePersonAsync(PersonModel personModel);
        Task<TaskModel> GetPersonById(string id);
        Task<TaskModel> GetPersonByEmail(string email);
        Task DeletePersonAsync(string id);
    }
}
