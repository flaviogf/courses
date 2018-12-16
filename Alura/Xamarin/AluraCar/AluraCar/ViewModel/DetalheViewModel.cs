using AluraCar.Model;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraCar.ViewModel
{
    class DetalheViewModel : BaseViewModel
    {
        public string TextoArCondicionado => $"Ar Condicionado R$ {(decimal)Opcionais.ArCondicionado}";

        public string TextoFreioAbs => $"Freio Abs R$ {(decimal)Opcionais.FreioAbs}";

        public string TextoMp3Player => $"Mp3 Player R$ {(decimal)Opcionais.Mp3Player}";

        public string ValorTotal => Veiculo.ValorFormatado;

        public bool TemArCondicionado
        {
            get => Veiculo.TemArCondicionado;
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemFreioAbs
        {
            get => Veiculo.TemFreioAbs;
            set
            {
                Veiculo.TemFreioAbs = value;
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMp3Player
        {
            get => Veiculo.TemMp3Player;
            set
            {
                Veiculo.TemMp3Player = value;
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public Veiculo Veiculo { get; set; }

        public ICommand Proximo { get; set; }

        public DetalheViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;
            Proximo = new Command(() =>
            {
                MessagingCenter.Send(veiculo, "Proximo");
            });
        }
    }
}
