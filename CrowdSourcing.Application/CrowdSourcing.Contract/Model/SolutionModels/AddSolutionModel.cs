namespace CrowdSourcing.Contract.Model.SolutionModels
{
    public class AddSolutionModel
    {
        public int Id { get; set; }
        public string AdminId { get; set; }       
        public string ExpertId { get; set; }     
        public int TaskDataId { get; set; }
        public int Status { get; set; }
    }
}
