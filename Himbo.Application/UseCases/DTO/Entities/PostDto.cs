using Himbo.Application.UseCases.DTO.Common;
using Himbo.Application.UseCases.DTO.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Entities
{

    public abstract class PostDtoCommon : BaseDtoWithMeta
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string BannerImageId { get; set; }

    }

    public class PostDto : PostDtoCommon, IImageDto, IImagesDto
    {
        public string ImageFileName { get; set; }
        public List<string> ImageFileNames { get; set; }
        public IEnumerable<int> TagIds { get; set; }
    }

    public class PostDtoDetails : PostDtoCommon
    {
        public AuthorDtoBase Author { get; set; }
        public CategoryDtoBase Category { get; set; }
        public IEnumerable<TagDtoBase> Tags { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<UserDtoBase> UsersWhoLiked { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfComments { get; set; }
        public float AverageRating { get; set; }

    }

    public class PostDtoBase : BaseDtoWithTitle
    {
        public AuthorDtoBase Author { get; set; }
    }
}
