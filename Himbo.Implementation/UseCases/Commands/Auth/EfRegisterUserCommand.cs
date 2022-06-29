using FluentValidation;
using Himbo.Application.Emails;
using Himbo.Application.UseCases.Commands.Auth;
using Himbo.Application.UseCases.DTO;
using Himbo.DataAccess;
using Himbo.Domain;
using Himbo.Domain.Entities;
using Himbo.Implementation.Validators.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Commands.Auth
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

        #region UseCase
        public int Id => 1;
        public string Name => "Register User (EF)";
        public string Description => "Use case for registering new User using EF";
        #endregion

        public EfRegisterUserCommand
        (
            HimboDbContext context, 
            RegisterUserValidator validator,
            IEmailSender sender
        ) 
            : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public void Execute(RegisterDto request)
        {
            #region Validate
            _validator.ValidateAndThrow(request);
            #endregion

            #region Hash
            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            #endregion

            #region Create User
            var user = new User
            {
                Email = request.Email,
                PasswordHash = hash,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            #endregion

            #region Add User to Group
            var group = Context.Groups.FirstOrDefault(x => x.Name == "Regular User");
            user.Group = group; 
            #endregion

            #region Create User
            Context.Users.Add(user);
            Context.SaveChanges();
            #endregion

            #region Send Email
            _sender.Send(new MessageDto
            {
                To = request.Email,
                Title = "Successfull registration",
                Body = "In order to become full Himbo, please activate your account by clicking activation link..."
            });
            #endregion
        }
    }
}
