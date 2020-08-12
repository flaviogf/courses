using AluraCar.TableView.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AluraCar.TableView.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Vehicles.Add(new Azera());
            Vehicles.Add(new Fiesta());
            Vehicles.Add(new HB20());

            VehiclesListView.ItemsSource = Vehicles;

            VehiclesListView.ItemTapped += (sender, args) =>
            {
                var vehicle = args.Item as Vehicle;

                var accessoriesPage = new AccessoriesPage();

                accessoriesPage.Vehicle = vehicle;

                Navigation.PushAsync(accessoriesPage);
            };

            BindingContext = this;
        }

        public IList<Vehicle> Vehicles = new List<Vehicle>();
    }
}
