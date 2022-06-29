using Himbo.Domain.Common;
using Himbo.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.DataAccess
{
    public abstract class AuditableDbContext: DbContext
    {
        public IApplicationUser User { get; }
        public AuditableDbContext(DbContextOptions options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            foreach(var entry in this.ChangeTracker.Entries())
            {
                if(entry.Entity is BaseEntity e)
                {
                    switch(entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User?.Identity;
                            break;
                        case EntityState.Deleted:
                            e.DeletedAt = DateTime.UtcNow;
                            e.DeletedBy = User?.Identity;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
