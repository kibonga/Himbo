using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Himbo.Api.FileUpload
{
    public interface IFileUploader
    {
        string Upload(IFormFile file);
        List<string> UploadMany(List<IFormFile> files);
        void Remove(string path);
    }
}
