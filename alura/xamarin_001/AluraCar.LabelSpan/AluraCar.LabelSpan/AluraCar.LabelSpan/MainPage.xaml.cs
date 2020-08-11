using System.Collections.Generic;
using Xamarin.Forms;

namespace AluraCar.LabelSpan
{
    public partial class MainPage : ContentPage
    {
        public IList<Car> Cars { get; } = new List<Car>();

        public MainPage()
        {
            InitializeComponent();

            Cars.Add(new Car("Azera V6", 60_000));
            Cars.Add(new Car("Fiesta 2.0", 50_000));
            Cars.Add(new Car("HB20 S", 40_000));

            BindingContext = this;
        }

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var car = e.Item as Car;

            DisplayAlert("Selection", $"Car {car} was tapped", "OK");
        }
    }
}
