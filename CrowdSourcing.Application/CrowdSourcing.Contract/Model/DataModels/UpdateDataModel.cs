using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
