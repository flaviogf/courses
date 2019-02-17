using System.Collections.Generic;
using System.Linq;
using CarreiraCSharpAlura.ByteBank.Funcionarios;

namespace CarreiraCSharpAlura.ByteBank
{
    public class GerenciadorBonificacao
    {
        private readonly IList<Funcionario> _funcionarios = new List<Funcionario>();

        public decimal TotalBonificacao => _funcionarios.Sum(it => it.Bonificacao);

        public void Registra(Funcionario funcionario) => _funcionarios.Add(funcionario);
    }
}
