using AspNetCoreHero.Results;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.SignUp.Command.CreateRider
{
    public class CreateRiderCommand : IRequest<IResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ValidIdUrl { get; set; }
        public string PassportPhoto { get; set; }
        public string BikeDocument { get; set; }
    }
    public class CreateRiderCommandValidator : AbstractValidator<CreateRiderCommand>
    {
        public CreateRiderCommandValidator()
        {
            //Validate properties
            RuleFor(x => x.FirstName).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("Invalid name Format");
            RuleFor(x => x.LastName).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("Invalid name Format");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid Email address Format");
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(11).WithMessage("Invalid Phone number");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Invalid Password, must have 'ABCabcd723#$@'");
            RuleFor(x => x.ValidIdUrl).NotNull().NotEmpty().WithMessage("Id cannot be empty");
            RuleFor(x => x.BikeDocument).NotEmpty().NotNull().WithMessage("Document cannot be empty");
        }
    }
}
