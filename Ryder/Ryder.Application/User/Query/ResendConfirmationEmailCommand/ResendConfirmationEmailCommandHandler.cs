using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Ryder.Application.User.Query.ResendConfirmationEmail
{
    public class ResendConfirmationEmailCommandHandler : IRequestHandler<ResendConfirmationEmailCommand, ResendConfirmationEmailResponse>
    {
        private readonly IConfiguration _configuration;

        public ResendConfirmationEmailCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResendConfirmationEmailResponse> Handle(ResendConfirmationEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await SendConfirmationEmailAsync(request.Email);

                return new ResendConfirmationEmailResponse
                {
                    IsSuccess = true,
                    Message = "Confirmation email resent successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResendConfirmationEmailResponse
                {
                    IsSuccess = false,
                    Message = "Error resending confirmation email: " + ex.Message
                };
            }
        }

        private async Task SendConfirmationEmailAsync(string userEmail)
        {
            var smtpClient = new SmtpClient(_configuration["SmtpSettings:Server"])
            {
                Port = int.Parse(_configuration["SmtpSettings:Port"]),
                Credentials = new NetworkCredential(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]),
                EnableSsl = true
            };

            var message = new MailMessage
            {
                From = new MailAddress(_configuration["SmtpSettings:Username"], "Your Name"),
                Subject = "Confirmation Email",
                Body = "Please confirm your email."
            };

            message.To.Add(userEmail);

            await smtpClient.SendMailAsync(message);
        }
    }
}




