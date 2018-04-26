using CrowdSourcing.Contract.Interfaces;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;


namespace CrowdSourcing.Application.Web.Controllers
{
    [RoutePrefix("Download")]
    public class DownloadController : ApiController
    {
        private IDownloadService _downloadService;
        public DownloadController(IDownloadService downloadService)
        {
            _downloadService = downloadService;
        }

        [HttpGet]
        [Route("DownloadDataFiles/{id}")]
        public async Task<HttpResponseMessage> DownloadDataFiles(int id)
        {
            var zipFile = await _downloadService.DownloadArchiveAsyncByDataId(id);            
            return ZipContentResult(zipFile);
        }
       
        protected HttpResponseMessage ZipContentResult(ZipFile zipFile)
        {
           
            var pushStreamContent = new PushStreamContent((stream, content, context) =>
            {
               
                zipFile.Save(stream);
                
                stream.Close(); // After save we close the stream to signal that we are done writing.
            }, "application/zip");

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = pushStreamContent
        };
        }
    }
}
