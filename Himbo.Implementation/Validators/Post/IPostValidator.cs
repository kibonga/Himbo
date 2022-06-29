using FluentValidation;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Validators.Post
{
    public class IPostValidator: AbstractValidator<PostDto>
    {
        private readonly HimboDbContext _context;
        public IPostValidator(HimboDbContext context)
        {
            #region DbContext
            this._context = context;
            #endregion

            #region Validate
            RuleFor(x => x.Summary)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Summary is required")
                .NotEmpty().WithMessage("Summary cannot be empty")
                .MaximumLength(100).WithMessage("Maximum length for summary is 100 characters")
                .MinimumLength(3).WithMessage("Minimum length for summary is 3 characters");
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Title is required")
                .NotEmpty().WithMessage("Title cannot be empty")
                .MaximumLength(100).WithMessage("Maximum length for title is 50 characters")
                .MinimumLength(3).WithMessage("Minimum length for summary is 3 characters");
            RuleFor(x => x.Content)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Content is required")
                .NotEmpty().WithMessage("Content cannot be empty")
                .MinimumLength(3).WithMessage("Minimum length for content is 3 characters");
            RuleFor(x => x.AuthorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull().WithMessage("Author Id is required")
                .Must(x => _context.Users.Any(u => u.Id == x && u.IsActive))
                .WithMessage("Author Id is invalid");
            RuleFor(x => x.CategoryId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull().WithMessage("Category Id is required")
                .Must(x => _context.Categories.Any(c => c.Id == x && c.IsActive))
                .WithMessage("Category Id is invalid");
            RuleFor(x => x.TagIds) // Tags are not required(Optional), but when they are defined they cannot be empty and must be valid
                .Cascade(CascadeMode.Stop)
                //.NotEmpty().WithMessage("Tag Ids are required")
                .Must(ids => ids.Distinct().Count() == ids.Count())
                .WithMessage("Duplicate values are not allowed").When(TagsExist)
                .Must(CheckIdsAreValid).WithMessage("Invalid Ids were passed").When(TagsExist);
            #endregion
        }

        private bool CheckIdsAreValid(IEnumerable<int> ids)
        {
            var validIds = _context.Tags.Where(t => t.IsActive).Select(t => t.Id).ToList();
            return ids.All(id => validIds.Contains(id));
        }

        private bool TagsExist(PostDto dto)
        {
            return dto.TagIds != null;
        }
    }
}
