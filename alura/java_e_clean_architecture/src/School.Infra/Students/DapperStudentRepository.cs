using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using School.Domain.Students;

namespace School.Infra.Students
{
    public class DapperStudentRepository : IStudentRepository
    {
        private readonly IDbConnection _connection;

        public DapperStudentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task Add(Student student)
        {
            await _connection.ExecuteAsync("INSERT INTO Students VALUES (@Cpf, @Name, @Email)", param: new
            {
                Cpf = student.Cpf,
                Name = student.Name,
                Email = student.Email,
            });

            var phones = student.Phones.Select(it =>
            {
                return _connection.ExecuteAsync("INSERT INTO Phones VALUES(@DDD, @Number)", param: new
                {
                    DDD = it.DDD,
                    Number = it.Number,
                });
            });

            await Task.WhenAll(phones);
        }

        public Task<IEnumerable<Student>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> FindByCpf(string cpf)
        {
            throw new System.NotImplementedException();
        }
    }
}
