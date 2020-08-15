using AluraCar.TestDrive.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;

namespace AluraCar.TestDrive.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Test Drive";

            Vehicles = new List<Vehicle>
            {
                new Azera(),
                new Fiesta(),
                new HB20()
            };

            TappedVehicleCommand = new DelegateCommand<Vehicle>(TappedVehicle);
        }

        public IList<Vehicle> Vehicles { get; }

        public ICommand TappedVehicleCommand { get; }

        private async void TappedVehicle(Vehicle vehicle)
        {
            var parameters = new NavigationParameters
            {
                { "vehicle", vehicle }
            };

            await NavigationService.NavigateAsync("AccessoriesPage", parameters);
        }
    }
}
