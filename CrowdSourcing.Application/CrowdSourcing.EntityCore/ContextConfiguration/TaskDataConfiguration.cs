using CrowdSourcing.EntityCore.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class TaskDataConfiguration: EntityTypeConfiguration<TaskDataEntity>
    {
        public TaskDataConfiguration()
        {
            ToTable("TaskData");

            HasKey(td => td.Id);

            Property(td => td.DataId)
                .IsRequired();

            Property(td => td.TaskId)
                .IsRequired();

            Property(td => td.FinishDate)
                .IsOptional();

            HasRequired(td => td.Task)
                .WithMany(t => t.TaskDatas);

            HasRequired(td => td.Data)
               .WithMany(d => d.TaskDatas);


        }
    }
}
