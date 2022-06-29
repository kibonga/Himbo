using Himbo.Domain.Common;
using Himbo.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Entities
{
    public class Post : BaseEntityWithMeta, IImage, IImages
    {
        public string Content { get; set; }
        public string Summary { get; set; } // Short description to be displayed

        // References
        public int? BannerImageId { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public virtual Image Image { get; set; }
        public virtual User Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>(); // Post has a collection of images as well as single banner image
        public virtual ICollection<User> UsersWhoLiked { get; set; } = new List<User>(); // List of Users who liked the Post
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>(); // List of all comments related to the Post
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>(); // List of all tags related to the Post
        public virtual ICollection<PostMeta> PostMetas { get; set; } = new List<PostMeta>(); // List of all PostMetas related to the Post (eg. keywords, content, everything related to SEO)
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>(); // List of all Ratings related to the Post
    }
}
