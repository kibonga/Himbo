using Himbo.Domain.Common;
using Himbo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain
{
    public class Group: BaseEntitiyWithName
    {
/*        public int Id { get; set; }
        public string Name { get; set; }*/
        public virtual IEnumerable<UseCase> UseCases { get; set; } = new List<UseCase>();
        public virtual IEnumerable<User> Users { get; set; } = new List<User>();
    }
}
