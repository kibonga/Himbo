using Microsoft.AspNetCore.Http;

namespace Himbo.Api.Core.Dto.Common
{
    public interface IFormFileDto
    {
        public IFormFile File { get; set; }
    }
}
