using AluraCar.TestDrive.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;

namespace AluraCar.TestDrive.ViewModels
{
    public class AccessoriesPageViewModel : ViewModelBase
    {
        private Vehicle _vehicle;

        private bool _brakeOn;

        private bool _airConditonerOn;

        private bool _mp3PlayerOn;

        public AccessoriesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NextStepCommand = new DelegateCommand(NextStep);
        }

        public Vehicle Vehicle
        {
            get
            {
                var value = _vehicle;

                if (BrakeOn)
                {
                    value = new Brake(value);
                }

                if (AirConditionerOn)
                {
                    value = new AirConditioner(value);
                }

                if (MP3PlayerOn)
                {
                    value = new MP3Player(value);
                }

                return value;
            }
            set
            {
                SetProperty(ref _vehicle, value);
            }
        }

        public bool BrakeOn
        {
            get
            {
                return _brakeOn;
            }
            set
            {
                SetProperty(ref _brakeOn, value);

                RaisePropertyChanged(nameof(Vehicle));
            }
        }

        public bool AirConditionerOn
        {
            get
            {
                return _airConditonerOn;
            }
            set
            {
                SetProperty(ref _airConditonerOn, value);

                RaisePropertyChanged(nameof(Vehicle));
            }
        }

        public bool MP3PlayerOn
        {
            get
            {
                return _mp3PlayerOn;
            }
            set
            {
                SetProperty(ref _mp3PlayerOn, value);

                RaisePropertyChanged(nameof(Vehicle));
            }
        }

        public ICommand NextStepCommand { get; }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Vehicle = parameters.GetValue<Vehicle>("vehicle");
        }

        private async void NextStep()
        {
            var parameters = new NavigationParameters
            {
                {"vehicle", Vehicle }
            };

            await NavigationService.NavigateAsync("SchedulePage", parameters);
        }
    }
}
