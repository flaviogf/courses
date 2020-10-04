namespace School.Application.Students
{
    public class EnrollStudentDto
    {
        public EnrollStudentDto(string cpf, string name, string email, string password)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
        }

        public string Cpf { get; }

        public string Name { get; }

        public string Email { get; }

        public string Password { get; }
    }
}
