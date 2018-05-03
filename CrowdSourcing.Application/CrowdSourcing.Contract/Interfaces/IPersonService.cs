using CrowdSourcing.Contract.Model;
using CrowdSourcing.Contract.Model.PersonModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface IPersonService 
    {
        Task<IEnumerable<PersonModel>> GetAllPersonsAsync();
        Task<IEnumerable<ExpertForDropdown>> GetAllExperts();
        Task<PersonModel> AddPersonAsync(PersonModel personModel,string password,string role);
        Task<PersonModel> UpdatePersonAsync(string adminId, string name, string lastName, string email);
        Task<PersonWithRoleModel> GetPersonById(string id);
        Task<PersonWithRoleModel> GetPersonByEmail(string email);
        Task DeletePersonAsync(string id);
        Task<PersonModel> ChangePassword(string personId, string currentPassword, string password);
    }
}
