using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Model.FileModels
{
    public class UsersFiles
    {
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public int FileId { get; set; }
        public int Status { get; set; }
        public string FileName { get; set; }
    }
}
