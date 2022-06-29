using Himbo.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? LastLogin { get; set; }

        #region References
        public int? ImageId { get; set; }
        public int? GroupId { get; set; }
        public virtual Image Image { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<UseCase> AdditionalUseCases { get; set; } = new List<UseCase>(); // List of users use cases
        public virtual ICollection<UseCase> ForbiddenUseCases { get; set; } = new List<UseCase>(); // List of forbidden users use cases
        public virtual ICollection<Post> LikedPosts { get; set; } = new List<Post>(); // List of Posts that user has liked
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>(); // List of Posts that user has created
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>(); // List of Comments that user has created
        public virtual ICollection<Comment> LikedComments { get; set; } = new List<Comment>(); // List of Comments that user has liked
        public virtual ICollection<Rating> RatedPosts { get; set; } = new List<Rating>(); // List of all Ratings that the User has rated 
        #endregion
    }
}
