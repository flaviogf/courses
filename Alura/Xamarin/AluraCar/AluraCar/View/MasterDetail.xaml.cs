using AluraCar.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluraCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail(Usuario usuario)
        {
            InitializeComponent();
            Master = new MasterView(usuario);
            Detail = new NavigationPage(new ListagemVeiculosView());
        }
    }
}