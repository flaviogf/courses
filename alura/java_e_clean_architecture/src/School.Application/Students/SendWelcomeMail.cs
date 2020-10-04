using System.Threading.Tasks;
using School.Domain.Students;

namespace School.Application.Students
{
    public interface SendWelcomeMail
    {
        Task Send(Student student);
    }
}
