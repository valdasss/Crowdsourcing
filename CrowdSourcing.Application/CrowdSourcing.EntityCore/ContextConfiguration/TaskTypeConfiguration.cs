using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class TaskTypeConfiguration : EntityTypeConfiguration<TaskTypeEntity>
    {
        public TaskTypeConfiguration()
        {
            ToTable("TaskTypes");

            HasKey<int>(c => c.Id);

            Property(t => t.Name)
                .IsRequired();          
        }
    }
}
