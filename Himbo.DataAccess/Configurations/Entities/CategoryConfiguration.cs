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
    public class CategoryConfiguration : BaseEntityWithMetaConfiguration<Category>
    {
        protected override void ConfigureRulesWithMeta(EntityTypeBuilder<Category> builder)
        {
            // Indexes
            builder.HasIndex(x => x.Title).IsUnique();

            // Properties
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ParentId).IsRequired(false);

            // Relations
            builder.HasMany(x => x.Posts)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete category, all Posts will be deleted (No)

            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete Categroy, all child categories will be deleted (No)

            builder.HasOne(x => x.Image)
                .WithMany()
                .HasForeignKey(x => x.ImageId)
                .OnDelete(DeleteBehavior.SetNull); // If we delete Category, set image for that category to null (Yes)

        }
    }
}
