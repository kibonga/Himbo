using Himbo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Entities
{
    public class Rating : BaseEntity
    {
        public int NumberOfStars { get; set; }
        // References
        public int UserId { get; set; }
        public int PostId { get; set; }
        // UserId and PostId make composite primary key
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
