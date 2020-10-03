namespace School.Domain
{
    public class StudentBuilder
    {
        private Student _student;

        public StudentBuilder WithCpfNameEmail(string cpf, string name, string email)
        {
            _student = new Student(new Cpf(cpf), name, new Email(email));

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
