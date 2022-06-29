using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Common.Interfaces
{
    public interface IApplicationUser 
    {
        public string Identity { get; } // Username, Email, etc...
        public int Id { get; }
        public IEnumerable<int> AllowedUseCaseIds { get; }
        public IEnumerable<int> AdditionalUseCaseIds { get; }
        public IEnumerable<int> ForbiddenUseCaseIds { get; }
        public string Email { get; }
    }
}
