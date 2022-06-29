using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Himbo.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UseCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "GroupUseCase",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    UseCasesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUseCase", x => new { x.GroupsId, x.UseCasesId });
                    table.ForeignKey(
                        name: "FK_GroupUseCase_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUseCase_UseCases_UseCasesId",
                        column: x => x.UseCasesId,
                        principalTable: "UseCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalUseCases",
                columns: table => new
                {
                    AdditionalUseCasesId = table.Column<int>(type: "int", nullable: false),
                    UsersAdditionalUseCasesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalUseCases", x => new { x.AdditionalUseCasesId, x.UsersAdditionalUseCasesId });
                    table.ForeignKey(
                        name: "FK_AdditionalUseCases_UseCases_AdditionalUseCasesId",
                        column: x => x.AdditionalUseCasesId,
                        principalTable: "UseCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalUseCases_Users_UsersAdditionalUseCasesId",
                        column: x => x.UsersAdditionalUseCasesId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForbiddenUseCases",
                columns: table => new
                {
                    ForbiddenUseCasesId = table.Column<int>(type: "int", nullable: false),
                    UsersForbiddenUseCasesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForbiddenUseCases", x => new { x.ForbiddenUseCasesId, x.UsersForbiddenUseCasesId });
                    table.ForeignKey(
                        name: "FK_ForbiddenUseCases_UseCases_ForbiddenUseCasesId",
                        column: x => x.ForbiddenUseCasesId,
                        principalTable: "UseCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForbiddenUseCases_Users_UsersForbiddenUseCasesId",
                        column: x => x.UsersForbiddenUseCasesId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BannerImageId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Images_BannerImageId",
                        column: x => x.BannerImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostsImages",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsImages", x => new { x.ImagesId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_PostsImages_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsImages_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostsLikes",
                columns: table => new
                {
                    LikedPostsId = table.Column<int>(type: "int", nullable: false),
                    UsersWhoLikedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsLikes", x => new { x.LikedPostsId, x.UsersWhoLikedId });
                    table.ForeignKey(
                        name: "FK_PostsLikes_Posts_LikedPostsId",
                        column: x => x.LikedPostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsLikes_Users_UsersWhoLikedId",
                        column: x => x.UsersWhoLikedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostsMetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsMetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostsMetas_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostsRatings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    NumberOfStars = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsRatings", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostsRatings_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostsRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostsTags",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsTags", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostsTags_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsLikes",
                columns: table => new
                {
                    LikedCommentsId = table.Column<int>(type: "int", nullable: false),
                    UsersWhoLikedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsLikes", x => new { x.LikedCommentsId, x.UsersWhoLikedId });
                    table.ForeignKey(
                        name: "FK_CommentsLikes_Comments_LikedCommentsId",
                        column: x => x.LikedCommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentsLikes_Users_UsersWhoLikedId",
                        column: x => x.UsersWhoLikedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, null, "Regular User", null, null },
                    { 2, null, null, "Moderator", null, null },
                    { 3, null, null, "Admin", null, null }
                });

            migrationBuilder.InsertData(
                table: "UseCases",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 28, null, null, "Use case for querying all Comments using EF", "Query all Comments (EF)", null, null },
                    { 29, null, null, "Use case for creating new Post Like using EF", "Create Post Like (EF)", null, null },
                    { 30, null, null, "Use case for deleting existing Post Like using EF", "Delete Post Like (EF)", null, null },
                    { 31, null, null, "Use case for creating new Comment Like using EF", "Create Comment Like (EF)", null, null },
                    { 32, null, null, "Use case for deleting existing Comment Like using EF", "Delete Comment Like (EF)", null, null },
                    { 33, null, null, "Use case for creating new Post Rating using EF", "Create Post Rating (EF)", null, null },
                    { 34, null, null, "Use case for updating existing Post Rating using EF", "Update Post Rating (EF)", null, null },
                    { 35, null, null, "Use case for creating new Group using EF", "Create Group (EF)", null, null },
                    { 36, null, null, "Add UseCases to existing Group using EF", "Add UseCases to Group (EF)", null, null },
                    { 37, null, null, "Remove UseCases from existing Group using EF", "Remove UseCases from Group (EF)", null, null },
                    { 38, null, null, "Use case for deactivating existing Group using EF", "Deactivate Group (EF)", null, null },
                    { 40, null, null, "Use case for querying all Groups using EF", "Query all Groups (EF)", null, null },
                    { 27, null, null, "Use case for deleting existing Comment using EF", "Delete Comment (EF)", null, null },
                    { 41, null, null, "Use case for querying single Group using EF", "Query single Group (EF)", null, null },
                    { 42, null, null, "Use case for creating new UseCase using EF", "Create UseCase (EF)", null, null },
                    { 43, null, null, "Use case for querying all UseCases for single Group using EF", "Query all UseCases for Group (EF)", null, null },
                    { 44, null, null, "Use case for adding forbidden UseCase for User using EF", "Add Forbidden UseCase for User (EF)", null, null },
                    { 45, null, null, "Use case for removing forbidden UseCase for User using EF", "Remove Forbidden UseCase for User (EF)", null, null },
                    { 46, null, null, "Use case for adding additional UseCase for User using EF", "Add Additional UseCase for User (EF)", null, null },
                    { 47, null, null, "Use case for removing additional UseCase for User using EF", "Remove Additional UseCase for User (EF)", null, null },
                    { 48, null, null, "Use case for querying all additional UseCases for single User using EF", "Query all Additional UseCases for User (EF)", null, null },
                    { 49, null, null, "Use case for querying all forbidden UseCases for single User using EF", "Query all Forbidden UseCases for User (EF)", null, null },
                    { 50, null, null, "Use case for querying all Users for single Group using EF", "Query all Group Users (EF)", null, null },
                    { 39, null, null, "Use case for activating existing Group using EF", "Activate Group (EF)", null, null },
                    { 26, null, null, "Use case for activating existing Comment using EF", "Activate Comment (EF)", null, null },
                    { 25, null, null, "Use case for deactivating existing Comment using EF", "Deactivate Comment (EF)", null, null },
                    { 24, null, null, "Use case for updating existing Comment using EF", "Update Comment (EF)", null, null },
                    { 1, null, null, "Use case for registering new User using EF", "Register User (EF)", null, null },
                    { 2, null, null, "Use case for creating new Tag using EF", "Create Tag (EF)", null, null },
                    { 3, null, null, "Use case for updating existing Tag using EF", "Update Tag (EF)", null, null },
                    { 4, null, null, "Use case for deleting existing Tag using EF", "Delete Tag (EF)", null, null },
                    { 5, null, null, "Use case for querying all Tags using EF", "Query all Tags (EF)", null, null },
                    { 6, null, null, "Use case for querying single Tag using EF", "Query single Tag (EF)", null, null },
                    { 7, null, null, "Use case for deactivating existing Tag using EF", "Deactivate Tag (EF)", null, null },
                    { 8, null, null, "Use case for activating existing Tag using EF", "Activate Tag (EF)", null, null },
                    { 9, null, null, "Use case for creating new Category using EF", "Create Category (EF)", null, null },
                    { 10, null, null, "Use case for updating existing Category using EF", "Update Category (EF)", null, null },
                    { 11, null, null, "Use case for deactivating existing Category using EF", "Deactivate Category (EF)", null, null },
                    { 12, null, null, "Use case for activating existing Category using EF", "Activate Category (EF)", null, null }
                });

            migrationBuilder.InsertData(
                table: "UseCases",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 13, null, null, "Use case for querying all Categories using EF", "Query all Categories (EF)", null, null },
                    { 14, null, null, "Use case for querying single Category using EF", "Query single Category (EF)", null, null },
                    { 15, null, null, "Use case for deleting existing Category using EF", "Delete Category (EF)", null, null },
                    { 16, null, null, "Use case for creating new Post using EF", "Create Post (EF)", null, null },
                    { 17, null, null, "Use case for updating existing Post using EF", "Update Post (EF)", null, null },
                    { 18, null, null, "Use case for deactivating existing Post using EF", "Deactivate Category (EF)", null, null },
                    { 19, null, null, "Use case for activating existing Post using EF", "Activate Post (EF)", null, null },
                    { 20, null, null, "Use case for deleting existing Post using EF", "Delete Post (EF)", null, null },
                    { 21, null, null, "Use case for querying all Posts using EF", "Query all Posts (EF)", null, null },
                    { 22, null, null, "Use case for querying single Post using EF", "Query single Post (EF)", null, null },
                    { 23, null, null, "Use case for creating new Comment using EF", "Create Comment (EF)", null, null },
                    { 51, null, null, "Use case for changing Group for User using EF", "Change Group for User (EF)", null, null },
                    { 52, null, null, "Use case for querying all UseCase Logs using SP", "Query all UseCase Logs (SP)", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalUseCases_UsersAdditionalUseCasesId",
                table: "AdditionalUseCases",
                column: "UsersAdditionalUseCasesId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Title",
                table: "Categories",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsLikes_UsersWhoLikedId",
                table: "CommentsLikes",
                column: "UsersWhoLikedId");

            migrationBuilder.CreateIndex(
                name: "IX_ForbiddenUseCases_UsersForbiddenUseCasesId",
                table: "ForbiddenUseCases",
                column: "UsersForbiddenUseCasesId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUseCase_UseCasesId",
                table: "GroupUseCase",
                column: "UseCasesId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BannerImageId",
                table: "Posts",
                column: "BannerImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Title",
                table: "Posts",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_PostsImages_PostsId",
                table: "PostsImages",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsLikes_UsersWhoLikedId",
                table: "PostsLikes",
                column: "UsersWhoLikedId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsMetas_Key",
                table: "PostsMetas",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_PostsMetas_PostId",
                table: "PostsMetas",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsRatings_PostId",
                table: "PostsRatings",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsTags_TagsId",
                table: "PostsTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Title",
                table: "Tags",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UseCases_Name",
                table: "UseCases",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FirstName",
                table: "Users",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageId",
                table: "Users",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastName",
                table: "Users",
                column: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalUseCases");

            migrationBuilder.DropTable(
                name: "CommentsLikes");

            migrationBuilder.DropTable(
                name: "ForbiddenUseCases");

            migrationBuilder.DropTable(
                name: "GroupUseCase");

            migrationBuilder.DropTable(
                name: "PostsImages");

            migrationBuilder.DropTable(
                name: "PostsLikes");

            migrationBuilder.DropTable(
                name: "PostsMetas");

            migrationBuilder.DropTable(
                name: "PostsRatings");

            migrationBuilder.DropTable(
                name: "PostsTags");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UseCases");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
