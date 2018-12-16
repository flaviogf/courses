using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluraCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<HttpRequestException>(this, "ErrorLogin", err =>
            {
                DisplayAlert("Erro", "Não foi possível realizar o login", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<HttpRequestException>(this, "ErrorLogin");
        }
    }
}