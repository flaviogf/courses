using System;
using AluraCar.Model;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AluraCar.ViewModel
{
    public class AgendamentoViewModel
    {
        private const string UrlAgendamento = "http://aluracar.herokuapp.com/salvaragendamento";

        public Agendamento Agendamento { get; set; }

        public string Nome
        {
            get => Agendamento.Nome;
            set
            {
                Agendamento.Nome = value;
                Agendar.ChangeCanExecute();
            }
        }

        public string Email
        {
            get => Agendamento.Email;
            set
            {
                Agendamento.Email = value;
                Agendar.ChangeCanExecute();
            }
        }

        public string Telefone
        {
            get => Agendamento.Telefone;
            set
            {
                Agendamento.Telefone = value;
                Agendar.ChangeCanExecute();
            }
        }

        public Command Agendar { get; set; }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            Agendamento = new Agendamento(veiculo);
            Agendar = new Command(() =>
            {
                MessagingCenter.Send(Agendamento, "Agendar");
            },
            () =>
                !string.IsNullOrWhiteSpace(Nome) &&
                !string.IsNullOrWhiteSpace(Email) &&
                !string.IsNullOrWhiteSpace(Telefone)
            );
        }

        public async void SalvarAgendamento(Agendamento agendamento)
        {
            try
            {
                var cliente = new HttpClient();
                var dataAgendamento = new DateTime(
                    Agendamento.Data.Year, Agendamento.Data.Month, Agendamento.Data.Day,
                    Agendamento.Horario.Hours, agendamento.Horario.Minutes, Agendamento.Horario.Seconds
                );
                var json = JsonConvert.SerializeObject(new
                {
                    nome = Nome,
                    fone = Telefone,
                    email = Email,
                    carro = Agendamento.Veiculo.Nome,
                    preco = Agendamento.Veiculo.Preco,
                    dataAgendamento
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync(UrlAgendamento, content);
                if (response.IsSuccessStatusCode)
                {
                    MessagingCenter.Send(Agendamento, "SuccessAgendamento");
                    return;
                }
                throw new HttpRequestException("ErrorAgendamento");
            }
            catch (HttpRequestException exception)
            {
                MessagingCenter.Send(exception, "ErrorAgendamento");
            }
        }
    }
}
