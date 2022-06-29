using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases
{
    public interface ICommand<TRequest>: IUseCase
    {
        void Execute(TRequest request);
        #region Explanation
        // TRequest represents the type of data that is being passed

        //eg.
        // public void HandleCommand<TRequest>
        // (
        //      ICommand<TRequest> command,
        //      TRequest data
        // )

        // public void HanldeCommand<CreateCategoryDto>
        // (
        //      ICommand<CreateCategoryDto> command,
        //      CreateCategoryDto data
        // )

        // In this example <TRequest> is equivalent to <CreateCategoryDto>

        // Execute(TRequest request)
        // Execute(CreateCategoryDto data) 
        #endregion
    }
    public interface ICommand<Id, TRequest>: IUseCase
    {
        void Execute(Id id, TRequest request); 
    }
}
