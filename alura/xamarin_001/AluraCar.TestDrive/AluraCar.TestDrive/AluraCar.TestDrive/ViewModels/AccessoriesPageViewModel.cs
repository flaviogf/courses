using AluraCar.TestDrive.Models;
using Prism.Navigation;

namespace AluraCar.TestDrive.ViewModels
{
    public class AccessoriesPageViewModel : ViewModelBase
    {
        private Vehicle _vehicle;

        public AccessoriesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public Vehicle Vehicle
        {
            get
            {
                return _vehicle;
            }
            private set
            {
                SetProperty(ref _vehicle, value);
            }
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Vehicle = parameters.GetValue<Vehicle>("vehicle");
        }
    }
}
