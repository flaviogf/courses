namespace CarreiraCSharpAlura.ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        public string Nome { get; set; }

        public string CPF { get; private set; }

        public decimal Salario { get; protected set; }

        public abstract decimal Bonificacao { get; }

        public Funcionario(string cpf, decimal salario)
        {
            CPF = cpf;
            Salario = salario;
        }
    }
}
