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
            var host = default(string);

            var port = default(int);

            var username = default(string);

            var password = default(string);

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