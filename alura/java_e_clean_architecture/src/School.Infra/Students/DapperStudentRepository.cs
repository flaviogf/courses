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
            await _connection.ExecuteAsync("INSERT INTO Students VALUES (@Cpf, @Name, @Email, @PasswordHash)", param: new
            {
                Cpf = (string)student.Cpf,
                Name = student.Name,
                Email = (string)student.Email,
                PasswordHash = student.PasswordHash
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

        public async Task<IEnumerable<Student>> FindAll()
        {
            var students = await _connection.QueryAsync<Student>("SELECT * FROM Students");

            return students;
        }

        public async Task<Student> FindByCpf(string cpf)
        {
            var student = await _connection.QueryFirstOrDefaultAsync<Student>("SELECT * FROM Students WHERE Cpf = @Cpf", param: new
            {
                Cpf = cpf
            });

            var phones = await _connection.QueryAsync<Phone>("SELECT * FROM Phone WHERE StudentCpf = @Cpf", new
            {
                Cpf = cpf
            });

            foreach (var phone in phones)
            {
                student.AddPhone(phone.DDD, phone.Number);
            }

            return student;
        }
    }
}
