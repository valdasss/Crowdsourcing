namespace CrowdSourcing.Contract.Model.ReportModels
{
    public class DataUploadersReportModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TotalDataCount { get; set; }
        public int DataDeclinedCount { get; set; }
        public int DataAcceptedCount { get; set; }
        public int DataNotAssignedCount { get; set; }
        public int DataInProgressCount { get; set; }
    }
}
