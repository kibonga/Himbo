using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases.Commands.Rating;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Rating
{
    public class EfUpdateRatingCommand: EfUseCase, IUpdateRatingCommand
    {
        private readonly UpdateRatingValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 34;
        public string Name => "Update Post Rating (EF)";
        public string Description => "Use case for updating existing Post Rating using EF";
        #endregion


        public EfUpdateRatingCommand
        (
            HimboDbContext context,
            UpdateRatingValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(RatingDto request)
        {
            #region Validate Rating
            _validator.ValidateAndThrow(request);
            #endregion

            #region Create Rating
            var post = Context.Posts.FirstOrDefault(x => request.PostId.Value == x.Id);
            post.Ratings.FirstOrDefault(r => r.UserId == request.UserId && r.PostId == request.PostId).NumberOfStars = request.NumberOfStars.Value;
            #endregion

            #region Save
            Context.SaveChanges();
            #endregion
        }
    }
}

