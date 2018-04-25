using System;

namespace CrowdSourcing.Contract.Model.DataModels
{
    public class DataModel
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public string Description { get; set; }
        public DateTime UploadTime { get; set; }
        public int IsDone { get; set; }
    }
}
