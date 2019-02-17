using System;
using System.ComponentModel.DataAnnotations;

namespace CursoAspNetMvc5Alura.Web.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
