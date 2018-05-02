using CrowdSourcing.EntityCore.Context;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.Repository.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.UserManagment
{
    public class PersonRepository : IPersonRepository
    {
        private UserStore<PersonEntity> _userStore; 
        private UserManager<PersonEntity> _personManager;
        public PersonRepository()
        {
            _userStore = new UserStore<PersonEntity>(new CrowdSourcingContext());
            _personManager = new UserManager<PersonEntity>(_userStore);
        }

        public async Task<PersonEntity> AddPerson(PersonEntity person,string password,string role)
        {
            var result =await _personManager.CreateAsync(person,password);
            if (result.Succeeded)
            {
                if (role == "admin")
                {
                    var roles = new string[3];
                    roles[0] = role;
                    roles[1] = "user";
                    roles[2] = "expert";

                    await _personManager.AddToRolesAsync(person.Id, roles);
                }
                if (role == "expert")
                {
                    var roles = new string[2];
                    roles[0] = role;
                    roles[1] = "user";
                    await _personManager.AddToRolesAsync(person.Id, roles);
                }
                await _personManager.AddToRolesAsync(person.Id, role);
            }           
            return person;
        }

        public async Task DeletePerson(string id)
        {
            var person = await _personManager.FindByIdAsync(id);
            await _personManager.DeleteAsync(person);

        }

        public async Task<IEnumerable<PersonEntity>> GetAllPersons()
        {
            return await _personManager.Users.ToListAsync();
        }
        public async Task<IEnumerable<string>> GetPersonsRoles(string id)
        {
            return await _personManager.GetRolesAsync(id);
        }
        public async Task<IEnumerable<PersonEntity>> GetPersonByRoleId(string id)
        {
            var result = await _personManager.Users.Include(x => x.Roles).Where(x => x.Roles.Select(y => y.RoleId).Contains(id)).ToListAsync();
            return result;
        }

        public async Task<PersonEntity> GetPersonById(string id)
        {
            var person = await _personManager.FindByIdAsync(id);
            return person;
        }
        public async Task<PersonEntity> GetPersonByEmail (string email)
        {
            var person = await _personManager.FindByEmailAsync(email);
            return person;
        }


        public async Task<PersonEntity> UpdatePerson(PersonEntity person)
        {
            await _personManager.UpdateAsync(person);
            return person;
        }
       
    }
}
