using AluraCar.Model;
using AluraCar.View;
using Xamarin.Forms;

namespace AluraCar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "SuccessLogin", usuario => MainPage = new MasterDetail(usuario));
        }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
