using Himbo.Domain.Common;
using Himbo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain
{
    public class UseCase : BaseEntitiyWithName
    {
/*        public int Id { get; set; }
        public string Name { get; set; }*/
        public string Description { get; set; }
        public virtual IEnumerable<Group> Groups { get; set; } = new List<Group>();
        public virtual IEnumerable<User> UsersAdditionalUseCases { get; set; } = new List<User>();
        public virtual IEnumerable<User> UsersForbiddenUseCases { get; set; } = new List<User>();
    }
}
