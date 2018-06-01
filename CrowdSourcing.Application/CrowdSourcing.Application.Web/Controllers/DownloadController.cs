using CrowdSourcing.Contract.Helpers;
using CrowdSourcing.Contract.Interfaces;
using Ionic.Zip;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace CrowdSourcing.Application.Web.Controllers
{
    [RoutePrefix("Download")]
    public class DownloadController : ApiController
    {
        private IDownloadService _downloadService;
        private IFileService _fileService ;
        public DownloadController(IDownloadService downloadService,IFileService fileService)
        {
            _downloadService = downloadService;
            _fileService = fileService;
        }

        [HttpGet]
        [Route("DownloadDataFiles/{id}")]      
        public async Task<HttpResponseMessage> DownloadDataFiles(int id)
        {
            var zipFile = await _downloadService.DownloadArchiveAsyncByDataId(id);            
            return ZipContentResult(zipFile);
        }
        [HttpGet]
        [Route("DownloadGoodTaskFiles/{id}")]  
        public async Task<HttpResponseMessage> DownloadGoodTaskFiles(int id)
        {
            var zipFile = await _downloadService.DownloadGoodTaskFiles(id);
            return ZipContentResult(zipFile);
        }

        [HttpGet]
        [Route("DownloadFile/{id}")]
        public async Task<HttpResponseMessage> DownloadFile(int id)
        {
            HttpResponseMessage result = null;
            var file = await _fileService.GetFileBy(id);

            if (!File.Exists(file.Url))
            {
                result = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new StreamContent(new FileStream(file.Url, FileMode.Open, FileAccess.Read));
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = UrlParser.GetFileNameWithExtension(file.Url)
                };
            }

            return result;
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
