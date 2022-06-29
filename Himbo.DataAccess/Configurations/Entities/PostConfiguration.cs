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
    public class PostConfiguration : BaseEntityWithMetaConfiguration<Post>
    {
        protected override void ConfigureRulesWithMeta(EntityTypeBuilder<Post> builder)
        {
            // Indexes
            builder.HasIndex(x => x.Title);

            // Properties
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.BannerImageId).IsRequired(false);
            builder.Property(x => x.AuthorId).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.Summary).IsRequired().HasMaxLength(200); // Short description to be displayed

            // Relations
            builder.HasOne(x => x.Image) // For specific banner image
                .WithMany()
                .HasForeignKey(x => x.BannerImageId)
                .OnDelete(DeleteBehavior.SetNull); // If we delete Post, image will be set to Null (Yes)

            builder.HasMany(x => x.Images) // For all other images
                .WithMany(x => x.Posts)
                .UsingEntity(x => x.ToTable("PostsImages"));

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete Post, all Users will be deleted (No)

            builder.HasMany(x => x.UsersWhoLiked)
                .WithMany(x => x.LikedPosts)
                .UsingEntity(x => x.ToTable("PostsLikes"));

            builder.HasMany(x => x.PostMetas)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade); // If we delete Post, all PostMetas for that Post will be deleted (Yes)

            builder.HasMany(x => x.Ratings)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict); // If we delete Post, all Ratings will be deleted (?)
            // TODO: check if Cascade will make problem with Ratings table (UserId, PostId)
        }
    }
}
