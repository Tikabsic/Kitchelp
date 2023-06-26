
namespace Application.Interfaces
{
    public interface IEmailClient
    {
        Task SendEmailAsync(string recipient, string subject, string body);
    }
}
