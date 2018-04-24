using CrowdSourcing.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface IPersonService 
    {
        Task<IEnumerable<PersonModel>> GetAllPersonsAsync();
        Task<PersonModel> AddPersonAsync(PersonModel personModel,string password,string role);
        Task<PersonModel> UpdatePersonAsync(PersonModel personModel);
        Task<PersonWithRoleModel> GetPersonById(string id);
        Task<PersonWithRoleModel> GetPersonByEmail(string email);
        Task DeletePersonAsync(string id);
    }
}
