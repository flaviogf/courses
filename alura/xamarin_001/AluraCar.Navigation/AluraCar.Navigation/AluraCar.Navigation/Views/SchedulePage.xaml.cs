using AluraCar.Navigation.Models;
using Xamarin.Forms;

namespace AluraCar.Navigation.Views
{
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public Car Car { get; set; }
    }
}
