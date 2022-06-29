using Himbo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Entities
{
    public class PostMeta : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
        // References
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
