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
        private UserManager<PersonEntity> _manager;
        public PersonRepository()
        {
            _userStore = new UserStore<PersonEntity>(new CrowdSourcingContext());
            _manager = new UserManager<PersonEntity>(_userStore);
        }

        public async Task<PersonEntity> AddPerson(PersonEntity person,string password,string role)
        {
            var result =await _manager.CreateAsync(person,password);
            if (result.Succeeded)
            {
                if (role == "expert")
                {
                    var roles = new string[2];
                    roles[0] = role;
                    roles[1] = "user";
                    await _manager.AddToRolesAsync(person.Id, roles);
                }
                await _manager.AddToRolesAsync(person.Id, role);
            }           
            return person;
        }

        public async Task DeletePerson(string id)
        {
            var person = await _manager.FindByIdAsync(id);
            await _manager.DeleteAsync(person);

        }

        public async Task<IEnumerable<PersonEntity>> GetAllPersons()
        {
            return await _manager.Users.ToListAsync();
        }
        public async Task<IEnumerable<string>> GetPersonsRoles(string id)
        {
            return await _manager.GetRolesAsync(id);
        }

        public async Task<PersonEntity> GetPersonById(string id)
        {
            var person = await _manager.FindByIdAsync(id);
            return person;
        }
        public async Task<PersonEntity> GetPersonByEmail (string email)
        {
            var person = await _manager.FindByEmailAsync(email);
            return person;
        }


        public async Task<PersonEntity> UpdatePerson(PersonEntity person)
        {
            await _manager.UpdateAsync(person);
            return person;
        }
    }
}
