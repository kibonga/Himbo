using Himbo.DataAccess.Configurations.Common;
using Himbo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.DataAccess.Configurations.Entities
{
    public class ImageConfiguration : BaseEntityConfiguration<Image>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Image> builder)
        {
            // Indexes

            // Properties
            builder.Property(x => x.Path).IsRequired().HasMaxLength(200);

            // Relations
            builder.HasMany(x => x.Posts)
                .WithMany(x => x.Images);
        }
    }
}
