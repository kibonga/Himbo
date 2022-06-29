using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Common.Interfaces
{
    public interface IImageDto
    {
        public string ImageFileName { get; set; }
    }

    public interface IImagesDto
    {
        public List<string> ImageFileNames { get; set; }
    }
}
