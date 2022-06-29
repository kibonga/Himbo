using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases
{
    public abstract class EfUseCase // Centralized place for DI of current Database Context
    {
        protected EfUseCase(HimboDbContext context)
        {
            Context = context;
        }

        public HimboDbContext Context { get; }
    }
}
