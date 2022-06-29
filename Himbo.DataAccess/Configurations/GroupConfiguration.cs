using Himbo.DataAccess.Configurations.Common;
using Himbo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.DataAccess.Configurations
{
    public class GroupConfiguration : BaseEntityConfiguration<Group>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Group> builder)
        {

            #region Indexes
            builder.HasIndex(x => x.Name);
            #endregion

            #region Properties
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            #endregion

            #region Relations
            builder.HasMany(x => x.UseCases)
                .WithMany(x => x.Groups);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Seeder - Legacy
            builder.HasData(
                // Seeder Start

            #region Regular User
                new Group()
                {
                    Id = 1,
                    Name = "Regular User"
                },
            #endregion

            #region Moderator
                new Group()
                {
                    Id = 2,
                    Name = "Moderator"
                },
            #endregion

            #region Admin
                new Group()
                {
                    Id = 3,
                    Name = "Admin"
                }
            #endregion

                // Seeder End    
                ); 
            #endregion

        }
    }
}
