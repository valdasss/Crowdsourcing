using System;

namespace CrowdSourcing.Contract.Model.DataModels
{
    public class UpdateDataModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime UploadTime { get; set; }
        public int IsDone { get; set; }
    }
}
