using CrowdSourcing.EntityCore.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class TaskTypeConfiguration : EntityTypeConfiguration<TaskTypeEntity>
    {
        public TaskTypeConfiguration()
        {
            ToTable("TaskType");

            HasKey<int>(c => c.Id);

            Property(t => t.Name)
                .IsRequired();          
        }
    }
}
