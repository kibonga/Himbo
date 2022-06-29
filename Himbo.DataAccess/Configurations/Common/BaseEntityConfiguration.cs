using Himbo.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.DataAccess.Configurations.Common
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.UpdatedBy).HasMaxLength(50);
            builder.Property(x => x.DeletedBy).HasMaxLength(50);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            ConfigureRules(builder); // A method which will be redefined in derived class

            // IEntityTypeConfiguration is a interface which lets us use automatic configuration detection
            // eg. modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        protected abstract void ConfigureRules(EntityTypeBuilder<T> builder); // We define abstraction (protected method) which will be redefined in implementation(concrete class) 
    }
}
