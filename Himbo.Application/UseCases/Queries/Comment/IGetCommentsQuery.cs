using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.Queries.Comment
{
    /*    public interface IGetCommentsQuery: IQuery<BasePagedSearch, PagedResponse<CommentDto>>
        {
        }*/
    public interface IGetCommentsQuery: IQuery<int, BasePagedSearch, PagedResponse<CommentDtoDetails>>
    {
    }
}
