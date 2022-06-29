using Himbo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }
        // References
        //public virtual ICollection<Post> Posts = new List<Post>();
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        // Entities with images Posts, Users, Categories
    }
}
