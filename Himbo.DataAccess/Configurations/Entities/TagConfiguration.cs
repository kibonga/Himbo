using Himbo.DataAccess.Configurations.Common;
using Himbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.DataAccess.Configurations.Entities
{
    public class TagConfiguration : BaseEntityWithMetaConfiguration<Tag>
    {
        protected override void ConfigureRulesWithMeta(EntityTypeBuilder<Tag> builder)
        {
            // Indexes
            builder.HasIndex(x => x.Title).IsUnique();

            // Properties
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);


            // Relations
            builder.HasMany(x => x.Posts) // Can only be defined in one side of the N:M relation
                .WithMany(x => x.Tags)
                .UsingEntity(x => x.ToTable("PostsTags"));
        }
    }
}
