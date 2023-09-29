using AccountingApp.Application.Requests.Mail;
using System.Threading.Tasks;

namespace AccountingApp.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}