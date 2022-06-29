using Himbo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Entities
{
    public class Tag : BaseEntityWithMeta
    {
        // Refereneces
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>(); // List of all Post related to specific Tag

    }
}
