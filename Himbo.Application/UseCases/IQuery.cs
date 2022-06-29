using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases
{
    public interface IQuery<TRequest, TResult>: IUseCase
    {
        TResult Execute(TRequest search);
        #region Explanation
        // TRequest represents the type of data that is being Passed
        // TResult represents the type of data that is being Returned 
        #endregion
    }
    public interface IQuery<Id, TRequest, TResult> : IUseCase
    {
        TResult Execute(Id id, TRequest search);
    }
}
