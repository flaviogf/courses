using AluraCar.Model;
using AluraCar.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluraCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : TabbedPage
    {
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            BindingContext = new MasterViewModel(usuario);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "Editar", sender => CurrentPage = Children[1]);
            MessagingCenter.Subscribe<string>(this, "Salvar", sender => CurrentPage = Children[0]);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "Editar");
            MessagingCenter.Unsubscribe<string>(this, "Salvar");
        }
    }
}