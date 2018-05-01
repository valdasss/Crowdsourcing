using System;

namespace CrowdSourcing.Contract.Model.SolutionModels
{
    public class SolutionModelForDoubleCheck
    {
        public int SolutionId { get; set; }
        public string ExpertName { get; set; }
        public string ExpertLastName { get; set; }
        public DateTime? LatestUpdateDate { get; set; }
    }
}
