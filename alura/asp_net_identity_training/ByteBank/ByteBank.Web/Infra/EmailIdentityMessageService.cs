using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ByteBank.Web.Infra
{
    public class EmailIdentityMessageService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var host = "smtp.mailtrap.io";

            var port = 2525;

            var username = "505c603ac7db70";

            var password = "5d35221e336b3b";

            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            client.Send("no-reply@bytebank.com.br", message.Destination, message.Subject, message.Body);

            return Task.CompletedTask;
        }
    }
}