using System.Threading.Tasks;

namespace EmailSender.Smtp.Core
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}