using System.Collections.Generic;
using Xamarin.Forms;

namespace AluraCar.ListView
{
    public partial class MainPage : ContentPage
    {
        public IList<Car> Cars { get; } = new List<Car>();

        public MainPage()
        {
            InitializeComponent();

            Cars.Add(new Car("Azera V6", 60000));
            Cars.Add(new Car("Fiesta 2.0", 50000));
            Cars.Add(new Car("HB20 S", 40000));

            BindingContext = this;
        }
    }
}
