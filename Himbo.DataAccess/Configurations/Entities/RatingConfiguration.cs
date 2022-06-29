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
    public class RatingConfiguration : BaseEntityConfiguration<Rating>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Rating> builder)
        {
            // Composite key
            builder.HasKey(x => new { x.UserId, x.PostId }); // Sets a composite key

            // Indexes
            // Should indexes even be defined? NumberOfStars?

            // Properties
            builder.Property(x => x.NumberOfStars).IsRequired(); // TODO: check how to add int(1-5) constraint

            // Relations
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete Rating, Post will be deleted (No) 

            builder.HasOne(x => x.User)
                .WithMany(x => x.RatedPosts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete Rating, User will be deleted (No) 
        }
    }
}
