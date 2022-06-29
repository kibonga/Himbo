using Himbo.Api.Core.Dto.Common;
using Himbo.Application.UseCases.DTO.Entities;
using Microsoft.AspNetCore.Http;

namespace Himbo.Api.Core.Dto
{
    public class CategoryDtoWithImage: CategoryDto, IFormFileDto
    {
        public IFormFile File { get; set; }
    }
}
