using Himbo.Application.UseCases.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Entities
{
    public class TagDto : BaseDtoWithMeta
    {
    }

    public class TagDtoBase : BaseDtoWithTitle { }

    /*    public class CreateTagDto: MetaDto // We want all data, but without Id (Create)
        {
        }

        public class UpdateTagDto : BaseDtoWithMeta // We want all data, along with Id (Delete)
        {
        }

        public class DetailsTagDto : BaseDtoWithMeta { }*/
}
