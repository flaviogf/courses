using System.Net.Http;
using AluraCar.Model;
using AluraCar.ViewModel;
using Xamarin.Forms;

namespace AluraCar.View
{
    public partial class ListagemVeiculosView: ContentPage
    {
        public ListagemVeiculosViewModel Context => BindingContext as ListagemVeiculosViewModel;

        public ListagemVeiculosView()
        {
            InitializeComponent();
            BindingContext = new ListagemVeiculosViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Context.GetVeiculos();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", veiculo =>
            {
                Navigation.PushAsync(new DetalheView(veiculo));
            });
            MessagingCenter.Subscribe<HttpRequestException>(this, "ErrorGetVeiculos", err =>
            {
                DisplayAlert("Erro", "Não foi possível listar os veículos", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<HttpRequestException>(this, "ErrorGetVeiculos");
        }
    }
}
