using MailSender.Models;
using System.Threading.Tasks;

namespace MailSender.Service
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
