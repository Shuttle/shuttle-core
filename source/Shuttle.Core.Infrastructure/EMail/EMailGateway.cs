using System.Net.Mail;
using System.Text;

namespace Shuttle.Core.Infrastructure
{
	public class EMailGateway : IEMailGateway
	{
		public void SendMail(MailMessage message)
		{
			var smtp = new SmtpClient();

			smtp.Send(message);

			Log.For(this).For(this).Debug(string.Format("E-Mail sent to {0} with subject '{1}'.", ToList(message), message.Subject));
		}

		private static string ToList(MailMessage message)
		{
			var result = new StringBuilder();

			foreach (var item in message.To)
			{
				result.AppendFormat("{0}{1} ({2})", result.Length > 0 ? "; " : string.Empty, item.DisplayName,
									item.Address);
			}

			return result.ToString();
		}
	}
}
