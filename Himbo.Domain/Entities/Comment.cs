using Himbo.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        // References
        public int? ParentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<User> UsersWhoLiked { get; set; } = new List<User>(); // List of users who liked, Likes on comment
        public virtual ICollection<Comment> Children { get; set; } = new List<Comment>(); // List of child comments
    }
}
