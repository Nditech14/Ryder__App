
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using MediatR;

namespace Ryder.Application.User.Query.ResendConfirmationEmail
{
    public class ResendConfirmationEmailCommandHandler : IRequestHandler<ResendConfirmationEmailCommand, ResendConfirmationEmailResponse>
    {
        public async Task<ResendConfirmationEmailResponse> Handle(ResendConfirmationEmailCommand request, CancellationToken cancellationToken)
        {
            // Implement the logic to resend confirmation email
            // This may involve sending an email to the user with a link to confirm their email address.
            // You might use services like SendGrid, SMTP, or any other email service you prefer.

            // Return a success result if the email was sent successfully.
            return new ResendConfirmationEmailResponse
            {
                IsSuccess = true, // Set to true if the email was successfully resent
                Message = "Confirmation email resent successfully"
            };
        }
    }
}



