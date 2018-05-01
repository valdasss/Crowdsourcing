using CrowdSourcing.Contract.Model.FileModels;
using System;
using System.Collections.Generic;

namespace CrowdSourcing.Contract.Model.SolutionModels
{
    public class SolutionInfoModel
    {
        public int SolutionId { get; set; }
        public string AssignerName { get; set; }
        public string AssignerLastName { get; set; }
        public int DataId { get; set; }
        public IEnumerable<FileForDetailsModel> Files { get; set; }
        public int Status { get; set; }
        public DateTime AssignDate { get; set; }
        public string UploadersComment { get; set; }
        public string ExpertsComment { get; set; }

    }
}
