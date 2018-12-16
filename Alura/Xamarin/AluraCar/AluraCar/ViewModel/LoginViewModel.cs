using AluraCar.Dto;
using AluraCar.Service;
using Xamarin.Forms;

namespace AluraCar.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _usuario = "joao@alura.com.br";
        public string Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                Entrar.ChangeCanExecute();
            }
        }

        private string _senha = "alura123";
        public string Senha
        {
            get => _senha;
            set
            {
                _senha = value;
                Entrar.ChangeCanExecute();
            }
        }

        public Command Entrar { get; set; }

        public LoginViewModel()
        {
            Entrar = new Command(async () =>
            {
                await LoginService.Autenticar(new LoginRequest { Email = Usuario, Senha = Senha });
            },
            () => !string.IsNullOrWhiteSpace(Usuario) && !string.IsNullOrWhiteSpace(Senha)
            );
        }
    }
}
