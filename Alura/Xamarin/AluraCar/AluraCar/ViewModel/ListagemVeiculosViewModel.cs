using AluraCar.Model;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AluraCar.ViewModel
{
    public class ListagemVeiculosViewModel : BaseViewModel
    {
        private const string UrlVeiculos = "http://aluracar.herokuapp.com";

        public ObservableCollection<Veiculo> Veiculos { get; set; } = new ObservableCollection<Veiculo>();

        private Veiculo _veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get => _veiculoSelecionado;
            set
            {
                _veiculoSelecionado = value;
                if (value != null)
                {
                    MessagingCenter.Send(value, "VeiculoSelecionado");
                }
            }
        }

        private bool _aguardar;
        public bool Aguardar
        {
            get => _aguardar;
            set
            {
                _aguardar = value;
                OnPropertyChanged();
            }
        }

        public async void GetVeiculos()
        {
            Aguardar = true;
            try
            {
                var cliente = new HttpClient();
                var response = await cliente.GetStringAsync(UrlVeiculos);
                var veiculos = JsonConvert.DeserializeObject<Veiculo[]>(response);
                Veiculos.Clear();
                veiculos.ForEach(veiculo => Veiculos.Add(veiculo));
            }
            catch (HttpRequestException exception)
            {
                MessagingCenter.Send(exception, "ErrorGetVeiculos");
            }
            Aguardar = false;
        }
    }
}
