using Himbo.Application.Emails;
using Himbo.Application.UseCases.Commands.Auth;
using Himbo.Application.UseCases.Commands.Category;
using Himbo.Application.UseCases.Commands.Comment;
using Himbo.Application.UseCases.Commands.Group;
using Himbo.Application.UseCases.Commands.Like;
using Himbo.Application.UseCases.Commands.Post;
using Himbo.Application.UseCases.Commands.Rating;
using Himbo.Application.UseCases.Commands.Tag;
using Himbo.Application.UseCases.Commands.UseCase;
using Himbo.Application.UseCases.Queries.Category;
using Himbo.Application.UseCases.Queries.Comment;
using Himbo.Application.UseCases.Queries.Group;
using Himbo.Application.UseCases.Queries.Post;
using Himbo.Application.UseCases.Queries.Tag;
using Himbo.Application.UseCases.Queries.UseCase;
using Himbo.Implementation.Emails;
using Himbo.Implementation.UseCases.Commands.Auth;
using Himbo.Implementation.UseCases.Commands.Category;
using Himbo.Implementation.UseCases.Commands.Comment;
using Himbo.Implementation.UseCases.Commands.Group;
using Himbo.Implementation.UseCases.Commands.Like;
using Himbo.Implementation.UseCases.Commands.Post;
using Himbo.Implementation.UseCases.Commands.Rating;
using Himbo.Implementation.UseCases.Commands.Tag;
using Himbo.Implementation.UseCases.Commands.UseCase;
using Himbo.Implementation.UseCases.Queries.Category;
using Himbo.Implementation.UseCases.Queries.Comment;
using Himbo.Implementation.UseCases.Queries.Group;
using Himbo.Implementation.UseCases.Queries.Post;
using Himbo.Implementation.UseCases.Queries.Tag;
using Himbo.Implementation.UseCases.Queries.UseCase;
using Himbo.Implementation.Validators.Auth;
using Himbo.Implementation.Validators.Category;
using Himbo.Implementation.Validators.Comment;
using Himbo.Implementation.Validators.Group;
using Himbo.Implementation.Validators.Like;
using Himbo.Implementation.Validators.Post;
using Himbo.Implementation.Validators.Rating;
using Himbo.Implementation.Validators.Tag;
using Himbo.Implementation.Validators.UseCase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation
{
    public static class ImplementationServicesRegistration
    {
        public static IServiceCollection ConfigureImplementationServices(this IServiceCollection services)
        {
            #region UseCases
            // Tags
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<ICreateTagCommand, EfCreateTagCommand>();
            services.AddTransient<IUpdateTagCommand, EfUpdateTagCommand>();
            services.AddTransient<IDeleteTagCommand, EfDeleteTagCommand>();
            services.AddTransient<IGetTagsQuery, EfGetTagsQuery>();
            services.AddTransient<IFindTagQuery, EfFindTagQuery>();
            services.AddTransient<IDeactivateTagCommand, EfDeactivateTagCommand>();
            services.AddTransient<IActivateTagCommand, EfActivateTagCommand>();
            // Categories
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IDeactivateCategoryCommand, EfDeactivateCategoryCommand>();
            services.AddTransient<IActivateCategoryCommand, EfActivateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IFindCategoryQuery, EfFindCategoryQuery>();
            // Posts
            services.AddTransient<ICreatePostCommand, EfCreatePostCommand>();
            services.AddTransient<IUpdatePostCommand, EfUpdatePostCommand>();
            services.AddTransient<IDeactivatePostCommand, EfDeactivatePostCommand>();
            services.AddTransient<IActivatePostCommand, EfActivatePostCommand>();
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();
            services.AddTransient<IGetPostsQuery, EfGetPostsQuery>();
            services.AddTransient<IFindPostQuery, EfFindPostQuery>();
            // Comments
            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
            services.AddTransient<IUpdateCommentCommand, EfUpdateCommentCommand>();
            services.AddTransient<IDeactivateCommentCommand, EfDeactivateCommentCommand>();
            services.AddTransient<IActivateCommentCommand, EfActivateCommentCommand>();
            services.AddTransient<IGetCommentsQuery, EfGetCommentsForPostQuery>();
            // Likes
            services.AddTransient<ICreatePostLikeCommand, EfCreatePostLikeCommand>();
            services.AddTransient<IDeletePostLikeCommand, EfDeletePostLikeCommand>();
            services.AddTransient<ICreateCommentLikeCommand, EfCreateCommentLikeCommand>();
            services.AddTransient<IDeleteCommentLikeCommand, EfDeleteCommentLikeCommand>();
            // Ratings
            services.AddTransient<ICreateRatingCommand, EfCreateRatingCommand>();
            services.AddTransient<IUpdateRatingCommand, EfUpdateRatingCommand>();
            // Groups
            services.AddTransient<ICreateGroupCommand, EfCreateGroupCommand>();
            services.AddTransient<IAddGroupUseCasesCommand, EfAddGroupUseCasesCommand>();
            services.AddTransient<IRemoveGroupUseCasesCommand, EfRemoveGroupUseCasesCommand>();
            services.AddTransient<IDeactivateGroupCommand, EfDeactivateGroupCommand>();
            services.AddTransient<IActivateGroupCommand, EfActivateGroupCommand>();
            services.AddTransient<IGetGroupsQuery, EfGetGroupsQuery>();
            services.AddTransient<IFindGroupQuery, EfFindGroupQuery>();
            services.AddTransient<IGetGroupUsersQuery, EfGetGroupUsersQuery>();
            services.AddTransient<IChangeUserGroupCommand, EfChangeUserGroupCommand>();
            // UseCases
            services.AddTransient<ICreateUseCaseCommand, EfCreateUseCaseCommand>();
            services.AddTransient<IGetUseCasesQuery, EfGetUseCasesQuery>();
            services.AddTransient<IAddForbiddenUseCaseCommand, EfAddForbiddenUseCaseCommand>();
            services.AddTransient<IRemoveForbiddenUseCaseCommand, EfRemoveForbiddenUseCaseCommand>();
            services.AddTransient<IAddAdditionalUseCaseCommand, EfAddAdditionalUseCaseCommand>();
            services.AddTransient<IRemoveAdditionalUseCaseCommand, EfRemoveAdditionalUseCaseCommand>();
            services.AddTransient<IGetAdditionalUseCasesQuery, EfGetAdditionalUseCasesQuery>();
            services.AddTransient<IGetForbiddenUseCasesQuery, EfGetForbiddenUseCasesQuery>();
            services.AddTransient<IGetUseCaseLogsQuery, SpGetUseCaseLogsQuery>();
            #endregion

            #region Validators
            // User
            services.AddTransient<RegisterUserValidator>();
            // Tag
            services.AddTransient<CreateTagValidator>();
            services.AddTransient<UpdateTagValidator>();
            // Category
            services.AddTransient<ICategoryValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            // Post
            services.AddTransient<CreatePostValidator>();
            services.AddTransient<UpdatePostValidator>();
            services.AddTransient<IPostValidator>();
            // Comment
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<UpdateCommentValidator>();
            services.AddTransient<ICommentValidator>();
            // Like
            services.AddTransient<CreatePostLikeValidator>();
            services.AddTransient<CreateCommentLikeValidator>();
            services.AddTransient<ILikeValidator>();
            // Ratings
            services.AddTransient<IRatingValidator>();
            services.AddTransient<CreateRatingValidator>();
            services.AddTransient<UpdateRatingValidator>();
            // Groups
            services.AddTransient<AddGroupUseCasesValidator>();
            services.AddTransient<ChangeUserGroupValidator>();
            services.AddTransient<CreateGroupValidator>();
            services.AddTransient<IGroupUseCasesValidator>();
            services.AddTransient<IGroupValidator>();
            services.AddTransient<RemoveGroupUseCasesValidator>();
            // UseCases
            services.AddTransient<IUseCaseValidator>();
            services.AddTransient<CreateUseCaseValidator>();
            services.AddTransient<AddForbiddenUseCaseValidator>();
            services.AddTransient<AddAdditionalUseCaseValidator>();
            services.AddTransient<RemoveForbiddenUseCaseValidator>();
            services.AddTransient<RemoveAdditionalUseCaseValidator>();
            services.AddTransient<IForbiddenAdditionalUseCaseValidator>();
            services.AddTransient<SearchUseCaseLogsValidator>();
            #endregion

            #region Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); 
            #endregion

            return services;
        }
    }
}
