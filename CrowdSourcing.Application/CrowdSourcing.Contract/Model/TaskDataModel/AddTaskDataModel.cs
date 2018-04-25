using System.Collections.Generic;
using System.Web;

namespace CrowdSourcing.Contract.Model.TaskDataModel
{
    public class AddTaskDataModel
    {
        public int TaskId { get; set; }
        public string UploaderId { get; set; }
        public string UploaderRoleId { get; set; }
        public string Description { get; set; }
        public HttpFileCollection UploadedFiles {get;set;}
    }
}
