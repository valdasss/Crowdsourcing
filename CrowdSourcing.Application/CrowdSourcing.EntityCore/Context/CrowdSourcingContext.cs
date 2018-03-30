using CrowdSourcing.EntityCore.ContextConfiguration;
using CrowdSourcing.EntityCore.Entity;
using System.Data.Entity;

namespace CrowdSourcing.EntityCore.Context
{
    public class CrowdSourcingContext : BaseCrowdSourcingContext, ICrowdSourcingContext
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
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<PersonRoleEntity> PersonRoles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FileTypeConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new TaskTypeConfiguration());
        }
    }
}
