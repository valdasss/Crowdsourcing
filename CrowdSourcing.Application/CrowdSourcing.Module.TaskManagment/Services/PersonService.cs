using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.PersonModel;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            ValidateRegisterModel(personModel, password, role);
            var user = await _personRepository.GetPersonByEmail(personModel.Email);
            if (user != null)
            {
                throw new ValidationException("Email already exits");
            }
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


        public async Task<PersonModel> UpdatePersonAsync(string adminId,string name,string lastName,string email)
        {
            var personEntity = await _personRepository.GetPersonById(adminId);
            if (email != "")
            {
            var user = await _personRepository.GetPersonByEmail(email);
            if (user != null&&(user.Id!= adminId))
            {
                throw new ValidationException("Email already exits");
            }
            }
            personEntity.FirstName = name;
            personEntity.LastName = lastName;
            personEntity.Email = email;
            personEntity.UserName = email;
            await _personRepository.UpdatePerson(personEntity);
            return personEntity.ToModel();
        }
        public async Task<PersonModel> ChangePassword(string personId, string currentPassword,string password)
        {
            var personEntity = await _personRepository.ChangePassword(personId, currentPassword, password);
            return personEntity.ToModel();
        }

        public async Task<IEnumerable<ExpertForDropdown>> GetAllExperts()
        {
            var expertRole = await _roleService.GetRoleByName("expert");
            var experts = await _personRepository.GetPersonByRoleId(expertRole.Id);
            var modelList = new List<ExpertForDropdown>();
            foreach (var expert in experts)
            {
                var model = new ExpertForDropdown()
                {
                    ExpertId = expert.Id,
                    ExpertName = expert.FirstName,
                    ExpertLastName = expert.LastName
                };
                modelList.Add(model);
            }
            return modelList;
        }
        public async Task<IEnumerable<ExpertForDropdown>> GetAllUploaders()
        {
            var userRole = await _roleService.GetRoleByName("user");
            var users = await _personRepository.GetPersonByRoleId(userRole.Id);
            var modelList = new List<ExpertForDropdown>();
            foreach (var user in users)
            {
                var model = new ExpertForDropdown()
                {
                    ExpertId = user.Id,
                    ExpertName = user.FirstName,
                    ExpertLastName = user.LastName
                };
                modelList.Add(model);
            }
            return modelList;
        }

        public async Task<IEnumerable<PersonWithRoleModel>> GetAllPersonsExeptHimself(string personId)
        {
            var persons = await _personRepository.GetAllPersonsExeptHimself(personId);
            var list = new List<PersonWithRoleModel>();
            foreach (var person in persons)
            {
                var roles = await _personRepository.GetPersonsRoles(person.Id);
                if (roles.Contains("admin"))
                {
                    list.Add(person.ToModelWithRole("admin"));
                }
                else if (roles.Contains("expert"))
                {
                    list.Add(person.ToModelWithRole("expert"));
                }
                else
                {
                    list.Add( person.ToModelWithRole("user"));
                }         
            }
            return list;
        }
        private void ValidateRegisterModel(PersonModel model, string password, string role)
        {
            if(string.IsNullOrEmpty(model.LastName) ||string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.Email) 
                ||  string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role)||password.Count()<9)
            {
                throw new ValidationException("Bad data");
            }
        }
    }
}
