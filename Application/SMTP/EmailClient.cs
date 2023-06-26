using System.Net.Mail;
using System.Net;
using Domain.Exceptions;
using Application.Interfaces;

namespace Application.SMTP
{
    public sealed class EmailClient : IEmailClient
    {
        private SmtpClient _client = new SmtpClient()
        {
            Host = EmailCredentials.Host,
            Port = EmailCredentials.Port,
            EnableSsl = EmailCredentials.EnableSsl,
            Credentials = new NetworkCredential(EmailCredentials.EMailAddress, EmailCredentials.EMailPassword)
        };

        public async Task SendEmailAsync(string recipient, string subject, string body)
        {
            try
            {
                await _client.SendMailAsync(
                    new MailMessage(from: EmailCredentials.EMailAddress,
                                    to: recipient,
                                    subject,
                                    body));
            }
            catch
            {

                throw new EmptySMTPCredentialsException();
            }
        }
    }
}
