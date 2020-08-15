using AluraCar.TestDrive.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Windows.Input;

namespace AluraCar.TestDrive.ViewModels
{
    public class SchedulePageViewModel : ViewModelBase
    {
        private readonly IPageDialogService _dialogService;

        private Vehicle _vehicle;

        private string _name;

        private string _phone;

        private string _email;

        private DateTime _day;

        private TimeSpan _hour;

        public SchedulePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;

            BookCommand = new DelegateCommand(Book);
        }

        public Vehicle Vehicle
        {
            get
            {
                return _vehicle;
            }
            set
            {
                SetProperty(ref _vehicle, value);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                SetProperty(ref _phone, value);
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        public DateTime Day
        {
            get
            {
                return _day;
            }
            set
            {
                SetProperty(ref _day, value);
            }
        }

        public TimeSpan Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                SetProperty(ref _hour, value);
            }
        }

        public DateTime MinimumDate => DateTime.Today;

        public DateTime MaximumDate => DateTime.Today.AddMonths(1);

        public ICommand BookCommand { get; }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Vehicle = parameters.GetValue<Vehicle>("vehicle");
        }

        private async void Book()
        {
            await _dialogService.DisplayAlertAsync("Schedule", $@"A Test Drive to test the {Vehicle.Name} was booked in name of {Name} at {Day:MM-dd-yy} {Hour:hh\:mm}", "OK");
        }
    }
}
