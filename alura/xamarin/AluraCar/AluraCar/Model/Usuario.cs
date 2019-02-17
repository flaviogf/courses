using Xamarin.Forms;

namespace AluraCar.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public ImageSource Imagem { get; set; } = ImageSource.FromFile("sem_imagem.png");
    }
}
