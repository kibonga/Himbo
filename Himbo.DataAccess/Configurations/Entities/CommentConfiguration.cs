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
    public class CommentConfiguration : BaseEntityConfiguration<Comment>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Comment> builder)
        {
            // Indexes

            // Properties
            builder.Property(x => x.Content).IsRequired();

            // Relations
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children);

            builder.HasMany(x => x.UsersWhoLiked)
                .WithMany(x => x.LikedComments)
                .UsingEntity(x => x.ToTable("CommentsLikes"));
        }
    }
}
