using AutoMapper;
using FluentValidation;
using Himbo.Application.UseCases.Commands.Group;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.Implementation.Validators.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Group
{
    public class EfChangeUserGroupCommand: EfUseCase, IChangeUserGroupCommand
    {
        private readonly ChangeUserGroupValidator _validator;
        private readonly IMapper _mapper;

        #region UsesCase Data
        public int Id => 51;
        public string Name => "Change Group for User (EF)";
        public string Description => "Use case for changing Group for User using EF";
        #endregion

        public EfChangeUserGroupCommand
        (
            HimboDbContext context,
            ChangeUserGroupValidator validator,
            IMapper mapper
        )
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public void Execute(GroupDtoManager request)
        {
            #region Validate Group
            _validator.ValidateAndThrow(request);
            #endregion

            #region Change GroupId for User
            var user = Context.Users.FirstOrDefault(u => u.Id == request.UserId);
            user.GroupId = request.GroupId;
            #endregion

            #region Save;
            Context.SaveChanges();
            #endregion
        }
    }
}
