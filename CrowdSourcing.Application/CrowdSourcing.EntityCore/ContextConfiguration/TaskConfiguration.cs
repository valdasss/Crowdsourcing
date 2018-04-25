using CrowdSourcing.EntityCore.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class TaskConfiguration: EntityTypeConfiguration<TaskEntity>
    {
        public TaskConfiguration()
        {
            ToTable("Task");

            HasKey(t => t.Id);

            Property(t => t.Name)
                .IsRequired();

            Property(t => t.TaskTypeId)
                .IsOptional();

            Property(t => t.Description)
                .IsOptional();

            Property(t => t.Status)
                .IsRequired();

            HasRequired(t => t.TaskType)
                .WithMany(tp => tp.Tasks);

        }
    }
}
