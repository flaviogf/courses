using System;

namespace CursoAspNetMvc5Alura.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
