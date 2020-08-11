using AluraCar.Navigation.Models;
using Xamarin.Forms;

namespace AluraCar.Navigation.Views
{
    public partial class OptionalsPage : ContentPage
    {
        public OptionalsPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public Car Car { get; set; }

        private void Clicked(object sender, System.EventArgs e)
        {
            var schedulePage = new SchedulePage();

            schedulePage.Car = Car;

            Navigation.PushAsync(schedulePage);
        }
    }
}
