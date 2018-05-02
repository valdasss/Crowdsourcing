using System;

namespace CrowdSourcing.Contract.Model.SolutionModels
{
    public class SolutionShortInfoModel
    {
        public int Solutionid { get; set; }
        public string ExpertName { get; set; }
        public string ExpertLastName { get; set; }
        public string AdminName { get; set; }
        public string AdminLastName { get; set; }
        public DateTime SolutionCreationDate { get; set; }
        public int Status { get; set; }
        public int Rating { get; set; }


    }
}
