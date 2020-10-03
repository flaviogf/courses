using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Domain.Students
{
    public interface IStudentRepository
    {
        Task Add(Student student);

        Task<IEnumerable<Student>> FindAll();

        Task<Student> FindByCpf(string cpf);
    }
}
