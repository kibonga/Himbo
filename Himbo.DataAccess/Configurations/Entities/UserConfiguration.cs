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
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            // Indexes
            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);
            builder.HasIndex(x => x.Email).IsUnique();

            // Properties
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(30);
            builder.Property(x => x.PasswordHash).IsRequired();

            // Relations
            builder.HasOne(x => x.Image)
                .WithMany()
                .HasForeignKey(x => x.ImageId)
                .OnDelete(DeleteBehavior.SetNull); // If we Delete User, set the Image to Null (Yes)

            builder.HasMany(x => x.LikedPosts)
                .WithMany(x => x.UsersWhoLiked);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete Post, Author of the Post will be deleted (No)

            builder.HasMany(x => x.RatedPosts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete Author, all Ratings will be deleted (?)
            // TODO: check if Cascade will make problem with Ratings table (UserId, PostId)

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete User, all of his comments will be deleted (No)

            /*            builder.HasMany(x => x.LikedComments)
                            .WithMany(x => x.UsersWhoLiked);*/

            builder.HasMany(x => x.AdditionalUseCases)
                .WithMany(x => x.UsersAdditionalUseCases);
            
            builder.HasMany(x => x.ForbiddenUseCases)
                .WithMany(x => x.UsersForbiddenUseCases);
        }
    }
}
