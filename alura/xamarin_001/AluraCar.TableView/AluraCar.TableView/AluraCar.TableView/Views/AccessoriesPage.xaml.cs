using AluraCar.TableView.Models;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace AluraCar.TableView.Views
{
    public partial class AccessoriesPage : ContentPage
    {
        private readonly Stack<Snapshot> _snapshots = new Stack<Snapshot>();

        private Vehicle _vehicle;

        public AccessoriesPage()
        {
            InitializeComponent();

            BrakeSwitchCell.OnChanged += (sender, args) =>
            {
                if (args.Value)
                {
                    _snapshots.Push(Vehicle.Snapshot());

                    Vehicle = new Brake(Vehicle);

                    return;
                }

                if (!_snapshots.Any())
                {
                    return;
                }

                var snapshot = _snapshots.Pop();

                Vehicle = snapshot.Restore();
            };

            AirConditionerSwitchCell.OnChanged += (sender, args) =>
            {
                if (args.Value)
                {
                    _snapshots.Push(Vehicle.Snapshot());

                    Vehicle = new AirConditioner(Vehicle);

                    return;
                }

                if (!_snapshots.Any())
                {
                    return;
                }

                var snapshot = _snapshots.Pop();

                Vehicle = snapshot.Restore();
            };

            MP3PlayerSwitchCell.OnChanged += (sender, args) =>
            {
                if (args.Value)
                {
                    _snapshots.Push(Vehicle.Snapshot());

                    Vehicle = new MP3Player(Vehicle);

                    return;
                }

                if (!_snapshots.Any())
                {
                    return;
                }

                var snapshot = _snapshots.Pop();

                Vehicle = snapshot.Restore();
            };

            BindingContext = this;
        }

        public Vehicle Vehicle
        {
            get
            {
                return _vehicle;
            }
            set
            {
                _vehicle = value;

                OnPropertyChanged();
            }
        }
    }
}
