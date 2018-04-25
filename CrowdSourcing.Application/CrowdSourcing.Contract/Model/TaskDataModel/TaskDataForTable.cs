using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Model.TaskDataModel
{
    public class TaskDataForTable
    {
        public int DataId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime UploadDate { get; set; }
        public int Status { get; set; }

    }
}
