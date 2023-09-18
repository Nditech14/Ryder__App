using AspNetCoreHero.Results;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ryder.Application.User.Query.ResendConfirmationEmail
{
    public class ResendConfirmationEmailCommand : IRequest<ResendConfirmationEmailResponse>
    {
        [Required]
        public string Email { get; set; } 
    }
}

