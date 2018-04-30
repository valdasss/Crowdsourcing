using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Model.SolutionModels
{
    public class SolutionModelForExpertSolutionList
    {
        public int Solutionid { get; set; }
        public string AdminName { get; set; }
        public string AdminLastName { get; set; }
        public DateTime SolutionCreationDate { get; set; }
        public int Status { get; set; }
        public string TaskName { get; set; }
    }
}
