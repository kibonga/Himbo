using Himbo.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.Commands.Like
{
    public interface IDeletePostLikeCommand: ICommand<int, int>
    {
    }
}
