using Himbo.Application.UseCases.DTO.Common;
using Himbo.Application.UseCases.DTO.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Entities
{
    public abstract class CommentDtoCommon : BaseDto, IContentDto
    {
        public string Content { get; set; }
        public int? ParentId { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
    }
    public class CommentDto : CommentDtoCommon
    {
        public UserDtoBase User { get; set; }
    }

    public class CommentDtoDetails : CommentDtoCommon
    {
        public AuthorDtoBase User { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<UserDtoBase> UsersWhoLiked { get; set; }
    }

    public class CommentDtoUpdate : BaseDto, IContentDto
    {
        public string Content { get; set; }
    }

    public class CommentDtoList : BaseDto, IContentDto
    {
        public string Content { get; set; }
    }

}
