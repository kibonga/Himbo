using Himbo.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.Commands.UseCase
{
    public interface ICreateUseCaseCommand: ICommand<UseCaseDto>
    {
    }
}
