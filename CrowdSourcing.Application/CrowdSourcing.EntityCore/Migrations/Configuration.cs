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
            #region filetypes
            context.FileTypes.AddOrUpdate(new FileTypeEntity
            {
                Name = "docx",
                Id = 1
            });
            context.SaveChanges();
            context.FileTypes.AddOrUpdate(new FileTypeEntity
            {
                Name = "doc",
                Id = 2
            });
            context.SaveChanges();
            context.FileTypes.AddOrUpdate(new FileTypeEntity
            {
                Name = "pdf",
                Id = 3
            });
            context.SaveChanges();
            context.FileTypes.AddOrUpdate(new FileTypeEntity
            {
                Name = "mp3",
                Id = 4
            });
            context.SaveChanges();
           
           

            context.FileTypes.AddOrUpdate(new FileTypeEntity
            {
                Name = "waw",
                Id = 5
            });
            context.SaveChanges();
            context.FileTypes.AddOrUpdate(new FileTypeEntity
            {
                Name = "ogg",
                Id = 6
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
               
                managerPerson.Create(user, "123456789");
                string[] roles = new string[3];
                roles[0] = "user";
                roles[1] = "expert";
                roles[2] = "admin";
                managerPerson.AddToRoles(user.Id, roles);
            }
            if (!context.Users.Any(u => u.UserName == "expert@gmail.com"))
            {

                var user = new PersonEntity
                {
                    FirstName = "Valdas",
                    LastName = "Bartkus",
                    Email = "expert@gmail.com",
                    UserName = "expert@gmail.com"
                };

                managerPerson.Create(user, "123456789");
                string[] roles = new string[2];
                roles[0] = "user";
                roles[1] = "expert";              
                managerPerson.AddToRoles(user.Id, roles);
            }
            if (!context.Users.Any(u => u.UserName == "user@gmail.com"))
            {

                var user = new PersonEntity
                {
                    FirstName = "Tomas",
                    LastName = "Makaka",
                    Email = "user@gmail.com",
                    UserName = "user@gmail.com"
                };

                managerPerson.Create(user, "123456789");
                string[] roles = new string[1];
                roles[0] = "user";
                managerPerson.AddToRoles(user.Id, roles);
            }
            #endregion
            #region task
            context.Tasks.AddOrUpdate(new TaskEntity
            {
                Name = "Anglų kalbos teksto vertimas",
                Description = "Išversti tekstą",
                Status=0,
                TaskTypeId = 1,
                Id = 1
            });
            context.SaveChanges();
            #endregion
        }
    }
}
