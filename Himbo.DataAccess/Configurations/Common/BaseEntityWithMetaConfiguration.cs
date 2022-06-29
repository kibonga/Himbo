using Himbo.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.DataAccess.Configurations.Common
{
    public abstract class BaseEntityWithMetaConfiguration<T> : BaseEntityConfiguration<T>
        where T : BaseEntityWithMeta
    {
        protected override void ConfigureRules(EntityTypeBuilder<T> builder)
        {
            #region Meta - Optional
            builder.Property(x => x.Slug).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.MetaTitle).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.MetaDescription).IsRequired(false).HasMaxLength(200);
            #endregion

            ConfigureRulesWithMeta(builder);
        }

        protected abstract void ConfigureRulesWithMeta(EntityTypeBuilder<T> builder);
    }
}
