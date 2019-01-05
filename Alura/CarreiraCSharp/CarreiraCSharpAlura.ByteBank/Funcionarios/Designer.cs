namespace CarreiraCSharpAlura.ByteBank.Funcionarios
{
    public class Designer : Funcionario
    {
        public override decimal Bonificacao => Salario * 0.17M;

        public Designer(string cpf, decimal salario) : base(cpf, salario) { }
    }
}
