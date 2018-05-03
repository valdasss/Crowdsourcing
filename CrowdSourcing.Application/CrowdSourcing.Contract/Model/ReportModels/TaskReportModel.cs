namespace CrowdSourcing.Contract.Model.ReportModels
{
    public class TaskReportModel
    {
        public string TaskName { get; set; }
        public string TaskData { get; set; }
        public int TaskDataCount { get; set; }
        public int InProgressCount { get; set; }
        public int AcceptedSolutionsCount { get; set; }
        public int DeclinedSolutionsCount { get; set; }
    }
}
