using AspNetCoreHero.Results;
using MediatR;

namespace Ryder.Application.User.Query.ResendConfirmationEmail
{
    public class ResendConfirmationEmailCommand : IRequest<ResendConfirmationEmailResponse>
    {
        // Add any properties needed for the command (e.g., UserId, Email, etc.)
    }
}

