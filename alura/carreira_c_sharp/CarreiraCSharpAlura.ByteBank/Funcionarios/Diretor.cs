namespace CarreiraCSharpAlura.ByteBank.Funcionarios
{
    public class Diretor : Funcionario
    {
        public override decimal Bonificacao => Salario * 0.5M;

        public Diretor(string cpf, decimal salario) : base(cpf, salario) { }
    }
}
