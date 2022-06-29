using Himbo.Api.Core.Dto.Common;
using Himbo.Application.UseCases.DTO.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Himbo.Api.Core.Dto
{
    public class PostDtoWithImage : PostDto, IFormFileDto
    {
        public IFormFile File { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
