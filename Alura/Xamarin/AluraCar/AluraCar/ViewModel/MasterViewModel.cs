using System.IO;
using AluraCar.Interface;
using AluraCar.Model;
using Xamarin.Forms;

namespace AluraCar.ViewModel
{
    public class MasterViewModel : BaseViewModel
    {
        public Usuario Usuario { get; set; }

        public string Nome
        {
            get => Usuario.Nome;
            set
            {
                Usuario.Nome = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => Usuario.Email;
            set
            {
                Usuario.Email = value;
                OnPropertyChanged();
            }
        }

        public ImageSource Imagem
        {
            get => Usuario.Imagem;
            set
            {
                Usuario.Imagem = value;
                OnPropertyChanged();
            }
        }

        private bool _editando;
        public bool Editando
        {
            get => _editando;
            set
            {
                _editando = value;
                OnPropertyChanged();
            }
        }

        public Command EditarCommand { get; set; }

        public Command HabilitarEdicaoCommand { get; set; }

        public Command SalvarCommand { get; set; }

        public Command TirarFotoCommand { get; set; }

        public MasterViewModel(Usuario usuario)
        {
            Usuario = usuario;
            EditarCommand = new Command(() => MessagingCenter.Send("Editar", "Editar"));
            SalvarCommand = new Command(() =>
            {
                Editando = false;
                MessagingCenter.Send("Salvar", "Salvar");
            });
            HabilitarEdicaoCommand = new Command(() => Editando = true);
            TirarFotoCommand = new Command(() =>
            {
                DependencyService.Get<ICamera>().TirarFoto(foto => Imagem = ImageSource.FromStream(() => new MemoryStream(foto)));
            });
        }
    }
}
