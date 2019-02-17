using System.Net.Http;
using System.Text;
using AluraCar.Model;
using AluraCar.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluraCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel Context => BindingContext as AgendamentoViewModel;

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            BindingContext = new AgendamentoViewModel(veiculo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendar", async agendamento =>
            {
                var resposta = await DisplayAlert("Confirmar", "Deseja realmente realizar o agendamento?", "SIM", "NÃO");
                if (resposta)
                {
                    Context.SalvarAgendamento(agendamento);
                }
            });
            MessagingCenter.Subscribe<Agendamento>(this, "SuccessAgendamento", async agendamento =>
            {
                var mensagem = PegarMensagem(agendamento);
                await DisplayAlert("Agedamento", mensagem, "OK");
                await Navigation.PopToRootAsync();
            });
            MessagingCenter.Subscribe<HttpRequestException>(this, "ErrorAgendamento", err =>
            {
                DisplayAlert("Agendamento", "Falha ao realizar o agendamento, tente novamente mais tarde", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendar");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SuccessAgendamento");
            MessagingCenter.Unsubscribe<HttpRequestException>(this, "ErrorAgendamento");
        }

        private string PegarMensagem(Agendamento agendamento)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {agendamento.Nome}");
            sb.AppendLine($"Email: {agendamento.Email}");
            sb.AppendLine($"Telefone: {agendamento.Telefone}");
            sb.AppendLine($"Data: {agendamento.Data:dd/MM/yyyy}");
            sb.AppendLine($"Horario: {agendamento.Horario:hh\\:mm\\:ss}");
            return sb.ToString();
        }
    }
}