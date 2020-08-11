using AluraCar.Navigation.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AluraCar.Navigation.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Cars.Add(new Car("Azera V6", 60_000));
            Cars.Add(new Car("Fiesta 2.0", 50_000));
            Cars.Add(new Car("HB20 S", 40_000));

            BindingContext = this;
        }

        public IList<Car> Cars { get; } = new List<Car>();

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var car = e.Item as Car;

            var optionalsPage = new OptionalsPage();

            optionalsPage.Car = car;

            Navigation.PushAsync(optionalsPage);
        }
    }
}
