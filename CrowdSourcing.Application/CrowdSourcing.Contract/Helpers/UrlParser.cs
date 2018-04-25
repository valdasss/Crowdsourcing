using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Helpers
{
    public static class UrlParser
    {
        public static string GetFileFormatFromPathUrl(string pathUrl)
        {
            var extension = Path.GetExtension(pathUrl);
            return extension.Remove(0, 1);
        }
    }
}
