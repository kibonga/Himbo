using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.Queries.Group
{
    public interface IGetGroupsQuery: IQuery<BasePagedSearch, PagedResponse<GroupDtoBase>>
    {
    }
}
