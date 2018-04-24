using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class PersonService : IPersonService
    {

        private IPersonRepository _personRepository;
        private IRoleService _roleService;
        public PersonService(IPersonRepository personRepository,IRoleService roleService)
        {
            _personRepository = personRepository;
            _roleService = roleService;
        }

        public async Task<PersonModel> AddPersonAsync(PersonModel personModel,string password,string role)
        {
           
           var result = await _personRepository.AddPerson(personModel.ToEntity(), password,role);
            return result.ToModel();
        }

        public async Task DeletePersonAsync(string id)
        {
            await _personRepository.DeletePerson(id);
        }

        public async Task<IEnumerable<PersonModel>> GetAllPersonsAsync()
        {
            var persons = await _personRepository.GetAllPersons();
            return persons.Select(p => p.ToModel());
        }

        public async Task<PersonWithRoleModel> GetPersonById(string id)
        {
            var person = await _personRepository.GetPersonById(id);
            var roles = await _personRepository.GetPersonsRoles(id);
            if (roles.Contains("admin"))
            {
                return person.ToModelWithRole("admin");
            }
            else if (roles.Contains("expert"))
            {
                return person.ToModelWithRole("expert");
            }
            else
            {
                return person.ToModelWithRole("user");
            }
        }
        public async Task<PersonWithRoleModel> GetPersonByEmail(string email)
        {
            var person = await _personRepository.GetPersonByEmail(email);
            var roles = await _personRepository.GetPersonsRoles(person.Id);
            if (roles.Contains("admin"))
            {
                return person.ToModelWithRole("admin");
            }
            else if (roles.Contains("expert"))
            {
                return person.ToModelWithRole("expert");
            }
            else
            {
                return person.ToModelWithRole("user");
            }
        }


        public async Task<PersonModel> UpdatePersonAsync(PersonModel personModel)
        {
            var personEntity = await _personRepository.GetPersonById(personModel.Id);
            personEntity.FirstName = personModel.Name;
            personEntity.LastName = personModel.LastName;
            personEntity.Email = personModel.Email;
            personEntity.UserName = personModel.Email;
            await _personRepository.UpdatePerson(personEntity);
            return personEntity.ToModel();
        }
    }
}
