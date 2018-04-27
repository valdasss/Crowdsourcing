using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.Interface
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonEntity>> GetAllPersons();
        Task<IEnumerable<string>> GetPersonsRoles(string id);
        Task<IEnumerable<PersonEntity>> GetPersonByRoleId(string id);
        Task<PersonEntity> GetPersonById(string id);
        Task<PersonEntity> GetPersonByEmail(string email);
        Task<PersonEntity> AddPerson(PersonEntity person,string password,string role);
        Task<PersonEntity> UpdatePerson(PersonEntity person);
        Task DeletePerson(string id);

    }
}
