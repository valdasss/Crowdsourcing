using System;

namespace CrowdSourcing.Contract.Model.TaskDataModel
{
    public class ModelForDataReviewDropdown
    {
        public int TaskDataId { get; set; }
        public string UploaderName { get; set; }
        public string UploaderLastName { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
