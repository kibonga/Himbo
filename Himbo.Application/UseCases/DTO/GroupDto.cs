using Himbo.Application.UseCases.DTO.Common;
using Himbo.Application.UseCases.DTO.Common.Interfaces;
using Himbo.Application.UseCases.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO
{
    public class GroupDto: BaseDtoWithName
    {
    }

    public class GroupUseCasesIdsDto : BaseDto
    {
        public IEnumerable<int> UseCasesIds { get; set; }
    }

    public class GroupDtoBase: BaseDtoWithName
    {

    }

    public class GroupDtoDetails: BaseDtoWithName
    {
        public IEnumerable<UseCaseDto> UseCases { get; set; }
    }

    public class GroupDtoInfoBase: BaseDtoWithName
    {
        public int NumberOfUseCases { get; set; }
        public int NumberOfUsers { get; set; }
    }

    public class GroupDtoInfo: GroupDtoInfoBase
    {
        public IEnumerable<UserDtoBase> Users { get; set; }
        public IEnumerable<UseCaseDto> UseCases { get; set; }
    }

    public class GroupDtoManager
    {
        public int? UserId { get; set; }
        public int? GroupId { get; set; }
    }
}
