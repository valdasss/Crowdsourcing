using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace CrowdSourcing.EntityCore.Entity
{
    public class SolutionEntity
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
        public string ExpertId { get; set; }
        public int? SolutionReviewId { get; set; }
        public int TaskDataId { get; set; }
        public int Status { get; set; }
        public DateTime SolutionDate { get; set; }
        public string Comment { get; set; }
        
        public IdentityUserRole Administrator { get; set; }
        public IdentityUserRole Expert { get; set; }
        public SolutionEntity Solution { get; set; }
        public ICollection<SolutionEntity> SolutionReviews { get; set; }
        public TaskDataEntity TaskData { get; set; }

    }
}
