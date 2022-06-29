using Himbo.Application.UseCases.DTO.Common;
using Himbo.Application.UseCases.DTO.Common.Interfaces;
using Himbo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Entities
{
    public class CategoryDto : BaseDtoWithMeta
    {
        //public string ImageId { get; set; }
        //public string Path { get; set; } // TODO: Potentially remove
        public int? ParentId { get; set; }
        public CategoryDtoBase Parent { get; set; }
        public IEnumerable<CategoryDtoBase> Children { get; set; }
        public string ImageFileName { get; set; }
        public ImageDto Image { get; set; }
    }

    public class CategoryDtoBase : BaseDtoWithTitle
    {
        public ImageDto Image { get; set; }
    }

}
