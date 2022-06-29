using Himbo.Application.UseCases.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Entities
{
    public class UserDto
    {
    }

    public class UserDtoBase : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
