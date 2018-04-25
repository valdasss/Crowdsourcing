using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Model.FileModels
{
    public class FileModel
    {
        public int Id { get; set; }
        public int FileTypeId { get; set; }
        public int DataId { get; set; }
        public string Url { get; set; }
    }
}
