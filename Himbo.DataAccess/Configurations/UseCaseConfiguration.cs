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
    public class UseCaseConfiguration : BaseEntityConfiguration<UseCase>
    {
        protected override void ConfigureRules(EntityTypeBuilder<UseCase> builder)
        {
            #region Indexes
            builder.HasIndex(x => x.Name);
            #endregion

            #region Properties
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired();
            #endregion

            #region Relations
            builder.HasMany(x => x.UsersAdditionalUseCases)
                .WithMany(x => x.AdditionalUseCases)
                .UsingEntity(x => x.ToTable("AdditionalUseCases"));

            builder.HasMany(x => x.UsersForbiddenUseCases)
                .WithMany(x => x.ForbiddenUseCases)
                .UsingEntity(x => x.ToTable("ForbiddenUseCases"));

            builder.HasMany(x => x.Groups)
                .WithMany(x => x.UseCases);

            #endregion


            #region Seeder - Legacy
            builder.HasData(
                // Seeder Start

            #region Auth UseCases
                new UseCase()
                {
                    Id = 1,
                    Name = "Register User (EF)",
                    Description = "Use case for registering new User using EF"
                },
            #endregion

            #region Tag UseCases
                new UseCase()
                {
                    Id = 2,
                    Name = "Create Tag (EF)",
                    Description = "Use case for creating new Tag using EF"
                },
                new UseCase()
                {
                    Id = 3,
                    Name = "Update Tag (EF)",
                    Description = "Use case for updating existing Tag using EF"
                },
                new UseCase()
                {
                    Id = 4,
                    Name = "Delete Tag (EF)",
                    Description = "Use case for deleting existing Tag using EF"
                },
                new UseCase()
                {
                    Id = 5,
                    Name = "Query all Tags (EF)",
                    Description = "Use case for querying all Tags using EF"
                },
                new UseCase()
                {
                    Id = 6,
                    Name = "Query single Tag (EF)",
                    Description = "Use case for querying single Tag using EF"
                },
                new UseCase()
                {
                    Id = 7,
                    Name = "Deactivate Tag (EF)",
                    Description = "Use case for deactivating existing Tag using EF"
                },
                new UseCase()
                {
                    Id = 8,
                    Name = "Activate Tag (EF)",
                    Description = "Use case for activating existing Tag using EF"
                },
            #endregion

            #region Category UseCases
                new UseCase()
                {
                    Id = 9,
                    Name = "Create Category (EF)",
                    Description = "Use case for creating new Category using EF"
                },
                new UseCase()
                {
                    Id = 10,
                    Name = "Update Category (EF)",
                    Description = "Use case for updating existing Category using EF"
                },
                new UseCase()
                {
                    Id = 11,
                    Name = "Deactivate Category (EF)",
                    Description = "Use case for deactivating existing Category using EF"
                },
                new UseCase()
                {
                    Id = 12,
                    Name = "Activate Category (EF)",
                    Description = "Use case for activating existing Category using EF"
                },
                new UseCase()
                {
                    Id = 13,
                    Name = "Query all Categories (EF)",
                    Description = "Use case for querying all Categories using EF"
                },
                new UseCase()
                {
                    Id = 14,
                    Name = "Query single Category (EF)",
                    Description = "Use case for querying single Category using EF"
                },
                new UseCase()
                {
                    Id = 15,
                    Name = "Delete Category (EF)",
                    Description = "Use case for deleting existing Category using EF"
                },
            #endregion

            #region Post UseCases
                new UseCase()
                {
                    Id = 16,
                    Name = "Create Post (EF)",
                    Description = "Use case for creating new Post using EF"
                },
                new UseCase()
                {
                    Id = 17,
                    Name = "Update Post (EF)",
                    Description = "Use case for updating existing Post using EF"
                },
                new UseCase()
                {
                    Id = 18,
                    Name = "Deactivate Category (EF)",
                    Description = "Use case for deactivating existing Post using EF"
                },
                new UseCase()
                {
                    Id = 19,
                    Name = "Activate Post (EF)",
                    Description = "Use case for activating existing Post using EF"
                },
                new UseCase()
                {
                    Id = 20,
                    Name = "Delete Post (EF)",
                    Description = "Use case for deleting existing Post using EF"
                },
                new UseCase()
                {
                    Id = 21,
                    Name = "Query all Posts (EF)",
                    Description = "Use case for querying all Posts using EF"
                },
                new UseCase()
                {
                    Id = 22,
                    Name = "Query single Post (EF)",
                    Description = "Use case for querying single Post using EF"
                },
            #endregion

            #region Comment UseCases
                new UseCase()
                {
                    Id = 23,
                    Name = "Create Comment (EF)",
                    Description = "Use case for creating new Comment using EF"
                },
                new UseCase()
                {
                    Id = 24,
                    Name = "Update Comment (EF)",
                    Description = "Use case for updating existing Comment using EF"
                },
                new UseCase()
                {
                    Id = 25,
                    Name = "Deactivate Comment (EF)",
                    Description = "Use case for deactivating existing Comment using EF"
                },
                new UseCase()
                {
                    Id = 26,
                    Name = "Activate Comment (EF)",
                    Description = "Use case for activating existing Comment using EF"
                },
                new UseCase()
                {
                    Id = 27,
                    Name = "Delete Comment (EF)",
                    Description = "Use case for deleting existing Comment using EF"
                },
                new UseCase()
                {
                    Id = 28,
                    Name = "Query all Comments (EF)",
                    Description = "Use case for querying all Comments using EF"
                },
            #endregion

            #region Comment UseCases
                new UseCase()
                {
                    Id = 29,
                    Name = "Create Post Like (EF)",
                    Description = "Use case for creating new Post Like using EF"
                },
                new UseCase()
                {
                    Id = 30,
                    Name = "Delete Post Like (EF)",
                    Description = "Use case for deleting existing Post Like using EF"
                },
                new UseCase()
                {
                    Id = 31,
                    Name = "Create Comment Like (EF)",
                    Description = "Use case for creating new Comment Like using EF"
                },
                new UseCase()
                {
                    Id = 32,
                    Name = "Delete Comment Like (EF)",
                    Description = "Use case for deleting existing Comment Like using EF"
                },
            #endregion

            #region Rating UseCases
                new UseCase()
                {
                    Id = 33,
                    Name = "Create Post Rating (EF)",
                    Description = "Use case for creating new Post Rating using EF"
                },
                new UseCase()
                {
                    Id = 34,
                    Name = "Update Post Rating (EF)",
                    Description = "Use case for updating existing Post Rating using EF"
                },
            #endregion

            #region Group UseCases
                new UseCase()
                {
                    Id = 35,
                    Name = "Create Group (EF)",
                    Description = "Use case for creating new Group using EF"
                },
                new UseCase()
                {
                    Id = 36,
                    Name = "Add UseCases to Group (EF)",
                    Description = "Add UseCases to existing Group using EF"
                },
               new UseCase()
               {
                   Id = 37,
                   Name = "Remove UseCases from Group (EF)",
                   Description = "Remove UseCases from existing Group using EF"
               },
               new UseCase()
               {
                   Id = 38,
                   Name = "Deactivate Group (EF)",
                   Description = "Use case for deactivating existing Group using EF"
               }
               , new UseCase()
               {
                   Id = 39,
                   Name = "Activate Group (EF)",
                   Description = "Use case for activating existing Group using EF"
               }
               , new UseCase()
               {
                   Id = 40,
                   Name = "Query all Groups (EF)",
                   Description = "Use case for querying all Groups using EF"
               }
               , new UseCase()
               {
                   Id = 41,
                   Name = "Query single Group (EF)",
                   Description = "Use case for querying single Group using EF"
               },
            #endregion

            #region UseCase UseCases
                new UseCase()
                {
                    Id = 42,
                    Name = "Create UseCase (EF)",
                    Description = "Use case for creating new UseCase using EF"
                },
                new UseCase()
                {
                    Id = 43,
                    Name = "Query all UseCases for Group (EF)",
                    Description = "Use case for querying all UseCases for single Group using EF"
                },
                new UseCase()
                {
                    Id = 44,
                    Name = "Add Forbidden UseCase for User (EF)",
                    Description = "Use case for adding forbidden UseCase for User using EF"
                },
                new UseCase()
                {
                    Id = 45,
                    Name = "Remove Forbidden UseCase for User (EF)",
                    Description = "Use case for removing forbidden UseCase for User using EF"
                },
                new UseCase()
                {
                    Id = 46,
                    Name = "Add Additional UseCase for User (EF)",
                    Description = "Use case for adding additional UseCase for User using EF"
                },
                new UseCase()
                {
                    Id = 47,
                    Name = "Remove Additional UseCase for User (EF)",
                    Description = "Use case for removing additional UseCase for User using EF"
                },
                new UseCase()
                {
                    Id = 48,
                    Name = "Query all Additional UseCases for User (EF)",
                    Description = "Use case for querying all additional UseCases for single User using EF"
                },
                new UseCase()
                {
                    Id = 49,
                    Name = "Query all Forbidden UseCases for User (EF)",
                    Description = "Use case for querying all forbidden UseCases for single User using EF"
                },
            #endregion

            #region Group Again
                new UseCase()
                {
                    Id = 50,
                    Name = "Query all Group Users (EF)",
                    Description = "Use case for querying all Users for single Group using EF"
                },
                new UseCase()
                {
                    Id = 51,
                    Name = "Change Group for User (EF)",
                    Description = "Use case for changing Group for User using EF"
                },
            #endregion

            #region Stored Procedure
                new UseCase()
                {
                    Id = 52,
                    Name = "Query all UseCase Logs (SP)",
                    Description = "Use case for querying all UseCase Logs using SP"
                }
            #endregion

                // Seeder End
                ); 
            #endregion

        }
    }
}
