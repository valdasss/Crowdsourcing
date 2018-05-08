using System;

namespace CrowdSourcing.Contract.Model.SolutionModels
{
    public class ExpertSolutionsHistoryModel
    {
        public string UploaderName {get;set;}
        public string UploaderLastName { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }

    }
}
