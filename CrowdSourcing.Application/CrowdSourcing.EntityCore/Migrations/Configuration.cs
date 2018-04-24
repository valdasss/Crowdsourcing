namespace CrowdSourcing.EntityCore.Migrations
{
    using CrowdSourcing.EntityCore.Context;
    using CrowdSourcing.EntityCore.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrowdSourcing.EntityCore.Context.CrowdSourcingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrowdSourcing.EntityCore.Context.CrowdSourcingContext context)
        {
            #region TaskType
            context.TaskTypes.AddOrUpdate(new TaskTypeEntity
            {
                Name = "Vertimas",
                Id = 1
            });
            context.SaveChanges();

            context.TaskTypes.AddOrUpdate(new TaskTypeEntity
            {
                Name = "Įgarsinimas",
                Id = 2
            });
            context.SaveChanges();

            context.TaskTypes.AddOrUpdate(new TaskTypeEntity
            {
                Name = "Vertimas ir įgarsinimas",
                Id = 3
            });
            context.SaveChanges();
            #endregion
            #region Roles
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            if (!context.Roles.Any(r => r.Name == "admin"))
            {               
                var role = new IdentityRole { Name = "admin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "expert"))
            {
                var role = new IdentityRole { Name = "expert" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "user"))
            {
                var role = new IdentityRole { Name = "user" };
                manager.Create(role);
            }
            #endregion

            #region Users
            var storePerson = new UserStore<PersonEntity>(context);
            var managerPerson = new UserManager<PersonEntity>(storePerson);
            if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            {
                
                var user = new PersonEntity {
                    FirstName="John",
                    LastName = "Wicked",
                    Email = "admin@gmail.com",                   
                    UserName = "admin@gmail.com"
                };
                string[] roles = new string[3];
                roles[0] = "user";
                roles[0] = "expert";
                roles[0] = "admin";
                managerPerson.Create(user, "123456789");
                managerPerson.AddToRoles(user.Id, roles);
            }
            #endregion
        }
    }
}
