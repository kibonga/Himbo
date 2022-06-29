using Himbo.Application.UseCases.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Entities
{
    public abstract class LikeDtoCommon
    {
        public int? UsersWhoLikedId { get; set; }
    }

    public class LikeDto
    {
        public int? UsersWhoLikedId { get; set; }
        public int? LikedPostsId { get; set; }
        public int? LikedeCommentsId { get; set; }
        public int? LikedId { get; set; }
        public int? UserId { get; set; }
    }

    public class LikeDtoPost : LikeDtoCommon
    {
        public int? LikedPostsId { get; set; }
    }
    public class LikeDtoComment : LikeDtoCommon
    {
        public int? LikedCommentsId { get; set; }
    }
}
