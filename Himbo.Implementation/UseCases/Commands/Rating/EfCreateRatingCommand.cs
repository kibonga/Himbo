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
    public class EfCreateRatingCommand: EfUseCase, ICreateRatingCommand
    {
        private readonly CreateRatingValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 33;
        public string Name => "Create Post Rating (EF)";
        public string Description => "Use case for creating new Post Rating using EF";
        #endregion


        public EfCreateRatingCommand
        (
            HimboDbContext context,
            CreateRatingValidator validator,
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
            var rating = _mapper.Map<Domain.Entities.Rating>(request);
            post.Ratings.Add(rating);
            #endregion

            #region Save
            Context.SaveChanges();
            #endregion
        }
    }
}
