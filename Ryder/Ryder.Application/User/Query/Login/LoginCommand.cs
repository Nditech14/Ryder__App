using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AspNetCoreHero.Results;
using FluentValidation;
using MediatR;

namespace Ryder.Application.User.Query.Login
{
    public class LoginCommand : IRequest<IResult<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}

