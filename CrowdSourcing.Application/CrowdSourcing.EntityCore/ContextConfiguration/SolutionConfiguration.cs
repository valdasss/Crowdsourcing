using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.ContextConfiguration
{
    public class SolutionConfiguration : EntityTypeConfiguration<SolutionEntity>
    {
        public SolutionConfiguration()
        {
            ToTable("Solution");

            HasKey(s => s.Id);

            Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.SolutionReviewId)
                .IsOptional();

            Property(s => s.AdminId)
                .IsRequired();

            Property(s => s.Comment)
                .IsOptional();

            Property(s => s.ExpertId)
                .IsRequired();

            Property(s => s.TaskDataId)
                .IsRequired();

            Property(s => s.Status)
                .IsRequired();

            Property(s => s.SolutionDate)
                .IsOptional();

            Property(s => s.SolutionDate)
               .IsOptional();

            HasRequired(s => s.TaskData)
                .WithMany(td => td.Solutions)
                .WillCascadeOnDelete(false);

            HasRequired(s => s.Administrator)
                .WithMany()
                .HasForeignKey(s=>new { s.AdminId,s.AdminRoleId})
                .WillCascadeOnDelete(false);

            HasRequired(s => s.Expert)
                .WithMany()
                .HasForeignKey(s=>new { s.ExpertId, s.ExpertRoleId })
                .WillCascadeOnDelete(false);

            HasOptional(s => s.Solution)
                .WithMany(s => s.SolutionReviews)
                .HasForeignKey(s => s.SolutionReviewId);
            
        }
    }
}
