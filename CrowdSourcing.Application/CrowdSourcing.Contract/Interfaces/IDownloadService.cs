using Ionic.Zip;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface IDownloadService
    {
        Task<ZipFile> DownloadArchiveAsyncByDataId(int dataId);
    }
}
