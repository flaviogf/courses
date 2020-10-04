using System.Threading.Tasks;
using School.Application.Students;
using School.Domain.Students;

namespace School.Infra
{
    public class SMTPSendWelcomeMail : SendWelcomeMail
    {
        public Task Send(Student student)
        {
            return Task.CompletedTask;
        }
    }
}
