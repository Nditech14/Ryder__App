using MimeKit;
using MailKit.Net.Smtp;
using Ryder.Infrastructure.Interface;
using Ryder.Infrastructure.Common.Extensions;


namespace Ryder.Infrastructure.Implementation
{
    public class SmtpEmailService : ISmtpEmailService
    {
        private readonly EmailSettings _settings;

        public SmtpEmailService(EmailSettings settings)
        {
            _settings = settings;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(_settings.SenderName, _settings.SmtpUsername));
                email.To.Add(new MailboxAddress("", toEmail));
                email.Subject = subject;

                var body = new TextPart("plain")
                {
                    Text = message
                };

                var multipart = new Multipart { body };
                email.Body = multipart;

                using var client = new SmtpClient();
                await client.ConnectAsync(_settings.SmtpHost, _settings.SmtpPort, true);
                await client.AuthenticateAsync(_settings.SenderName, _settings.SmtpPassword);
                await client.SendAsync(email);
                await client.DisconnectAsync(true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
