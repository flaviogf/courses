namespace School.Domain.Students
{
    public class StudentBuilder
    {
        private Student _student;

        public StudentBuilder WithCpfNameEmailPasswordHash(string cpf, string name, string email, string passwordHash)
        {
            _student = new Student(new Cpf(cpf), name, new Email(email), passwordHash);

            return this;
        }

        public StudentBuilder WithPhone(string ddd, string number)
        {
            _student.AddPhone(ddd, number);

            return this;
        }

        public Student Build()
        {
            return _student;
        }
    }
}
