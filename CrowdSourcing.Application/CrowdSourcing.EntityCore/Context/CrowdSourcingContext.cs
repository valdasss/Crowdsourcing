using CrowdSourcing.EntityCore.ContextConfiguration;
using CrowdSourcing.EntityCore.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CrowdSourcing.EntityCore.Context
{

    public class CrowdSourcingContext : IdentityDbContext<PersonEntity>, ICrowdSourcingContext
    {
       
        public CrowdSourcingContext() : base("CrowdSourcingContext")
        {

        }
        public DbSet<TaskTypeEntity> TaskTypes { get; set; }
        public DbSet<TaskDataEntity> TaskDatas { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<DataEntity> Datas { get; set; }
        public DbSet<FileTypeEntity> FileTypes { get; set; }
        public DbSet<FileEntity> Files { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FileTypeConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new TaskTypeConfiguration());
            modelBuilder.Configurations.Add(new DataConfiguration());
            modelBuilder.Configurations.Add(new FileConfiguration());  
            modelBuilder.Configurations.Add(new PersonRoleConfiguration());
            modelBuilder.Configurations.Add(new SolutionConfiguration());
            modelBuilder.Configurations.Add(new TaskConfiguration());
            modelBuilder.Configurations.Add(new TaskDataConfiguration());
            modelBuilder.Configurations.Add(new LoginConfiguration());

        }
    }
}
