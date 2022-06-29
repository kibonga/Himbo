using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Common
{
    public class BaseDto
    {
        public int? Id { get; set; }
    }

    public class BaseDtoWithMeta : MetaDto // If we want to include Id
    {
        public int? Id { get; set; }
    }

    public class BaseDtoWithTitle : TitleDto
    {
        public int? Id { get; set; }
    }

    public class BaseDtoWithName: NameDto
    {
        public int? Id { get; set; }
    }

}
