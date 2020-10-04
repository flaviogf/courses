using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using School.Application.Students;
using School.Infra.Students;

namespace School.Presentation.Cli
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            using var connection = new SqlConnection("Server=localhost;Database=School;User Id=sa;Password=Test123!;");

            var repository = new DapperStudentRepository(connection);

            var hash = new MD5Hash();

            var enroll = new EnrollStudent(repository, hash);

            var data = new EnrollStudentDto("11100011100", "Frank", "frank@email.com", "123456");

            await enroll.Execute(data);
        }
    }
}
