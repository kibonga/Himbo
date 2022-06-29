using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Common
{
    public abstract class BaseEntityWithTitle : BaseEntity
    {
        public string Title { get; set; }
    }
}
