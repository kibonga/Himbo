using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Himbo.Domain.Entities;
using Himbo.DataAccess.Configurations.Common;

namespace Himbo.DataAccess.Configurations.Entities
{
    public class PostMetaConfiguration : BaseEntityConfiguration<PostMeta>
    {
        protected override void ConfigureRules(EntityTypeBuilder<PostMeta> builder)
        {
            // Indexes
            builder.HasIndex(x => x.Key);

            // Properties
            builder.Property(x => x.Key).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Value).IsRequired().HasMaxLength(100);

            // Relations
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostMetas)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete single PostMeta all Post would be deleted (No)
        }
    }
}
