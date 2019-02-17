using AluraCar.Model;
using AluraCar.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluraCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView: ContentPage
    {
        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            BindingContext = new DetalheViewModel(veiculo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", veiculo =>
            {
                Navigation.PushAsync(new AgendamentoView(veiculo));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}