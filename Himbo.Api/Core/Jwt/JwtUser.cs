using Himbo.Domain.Common.Interfaces;
using System.Collections.Generic;

namespace Himbo.Api.Core.Jwt
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }

        public int Id { get; set; }

        public IEnumerable<int> AllowedUseCaseIds { get; set; } = new List<int>();
        public IEnumerable<int> AdditionalUseCaseIds { get; set; } = new List<int>();
        public IEnumerable<int> ForbiddenUseCaseIds { get; set; } = new List<int>();
        public string Email { get; set; }

    }

    public class AnonymousUser : IApplicationUser
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        #region Allowed UseCases for AnonymousUser
        /*
            1. EfRegisterUserCommand (1)
            2. EfGetTagsQuery (5)
            4. EfFindTagQuery (6)
            5. EfGetCategoriesQuery (13)
            6. EfFindCategoryQuery (14)
            7. EfGetPostsQuery (21)
            8. EfFindPostQuery (22)
            9. EfGetCommentsQuery (28)
         */
        #endregion
        public IEnumerable<int> AllowedUseCaseIds => new List<int> { 1, 5, 6, 13, 14, 21, 22, 28 };
        public IEnumerable<int> AdditionalUseCaseIds => new List<int> { };
        public IEnumerable<int> ForbiddenUseCaseIds { get; set; } = new List<int>();

        public string Email => "himbo.user@kimur.com";
    }
}
