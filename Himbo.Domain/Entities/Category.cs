using Himbo.Domain.Common;
using Himbo.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Entities
{
    public class Category : BaseEntityWithMeta, IImage
    {
        // References
        public int? ImageId { get; set; }
        public int? ParentId { get; set; }
        public virtual Image Image { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; } = new List<Category>();
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
