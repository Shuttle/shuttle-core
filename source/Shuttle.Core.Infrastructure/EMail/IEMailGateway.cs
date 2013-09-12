using System.Net.Mail;

namespace Shuttle.Core.Infrastructure
{
    public interface IEMailGateway
    {
        void SendMail(MailMessage message);
    }
}
