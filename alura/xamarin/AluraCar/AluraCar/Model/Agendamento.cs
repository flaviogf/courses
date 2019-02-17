using System;

namespace AluraCar.Model
{
    public class Agendamento
    {
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Data { get; set; } = DateTime.Today;
        public TimeSpan Horario { get; set; }

        public Agendamento(Veiculo veiculo)
        {
            Veiculo = veiculo;
        }
    }
}
