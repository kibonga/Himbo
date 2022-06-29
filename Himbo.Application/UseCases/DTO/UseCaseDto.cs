using Himbo.Application.UseCases.DTO.Common;
using Himbo.Application.UseCases.DTO.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO
{
    public class UseCaseDto : BaseDtoWithName
    {
        public string Description { get; set; }
    }

    public class UseCaseDtoDetails: UseCaseDto
    {
        
    }

    public class UseCaseDtoManager
    {
        public int? UserId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
}
}
