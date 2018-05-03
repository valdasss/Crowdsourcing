namespace CrowdSourcing.Contract.Model.ReportModels
{
    public class ExpertReportModel
    {
        public string ExpertName { get; set; }
        public string ExpertLastName { get; set; }
        public int TotalDoneCount { get; set; }
        public int AcceptedCount { get; set; }
        public int DeclinedCount { get; set; }
        public int InProgress { get; set; }
    }
}
