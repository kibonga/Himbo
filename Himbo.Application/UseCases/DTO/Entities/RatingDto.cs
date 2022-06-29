using Himbo.Application.UseCases.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Entities
{
    public class RatingDto
    {
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public int? NumberOfStars { get; set; }
    }
}
