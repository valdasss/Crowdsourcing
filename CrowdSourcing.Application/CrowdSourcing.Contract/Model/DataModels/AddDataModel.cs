using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CrowdSourcing.Contract.Model
{
    public class AddDataModel
    {   public string UploaderId { get; set; }
        public string Description { get; set; }
        public List<HttpPostedFile> UploadedFiles { get; set; }
    }
}
