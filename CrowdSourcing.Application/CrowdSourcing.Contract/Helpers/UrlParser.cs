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
        public static string GetFileNameWithOutExtension(string pathUrl)
        {
            return Path.GetFileNameWithoutExtension(pathUrl);   
           
        }
        public static string GetFileNameWithExtension(string pathUrl)
        {
            return Path.GetFileName(pathUrl);

        }
        public static string GetDirectoryName(string pathUrl)
        {
            return  new DirectoryInfo(pathUrl).Name;

        }
        public static string GetDirectoryFullName(string pathUrl)
        {
            return new FileInfo(pathUrl).Directory.FullName;
        }
    }
}
