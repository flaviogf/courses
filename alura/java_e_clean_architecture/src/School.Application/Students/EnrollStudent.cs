using System.Threading.Tasks;
using School.Domain.Students;

namespace School.Application.Students
{
    public class EnrollStudent
    {
        private readonly IStudentRepository _studentRepository;

        private readonly IHash _hash;

        public EnrollStudent(IStudentRepository studentRepository, IHash hash)
        {
            _studentRepository = studentRepository;
            _hash = hash;
        }

        public async Task Execute(EnrollStudentDto data)
        {
            var cpf = new Cpf(data.Cpf);

            var name = data.Name;

            var email = new Email(data.Email);

            var passwordHash = await _hash.Make(data.Password);

            var student = new Student(cpf, name, email, passwordHash);

            await _studentRepository.Add(student);
        }
    }
}
