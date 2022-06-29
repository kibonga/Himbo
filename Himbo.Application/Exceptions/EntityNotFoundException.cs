using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityType, int id)
            : base($"Entity of type {entityType} with an Id of {id} was not found.")
        {
        }
        public EntityNotFoundException(string entityType)
            : base($"Entity of type {entityType} was not found.")
        {
        }
    }
}
