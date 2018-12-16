namespace AluraCar.Model
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemFreioAbs { get; set; }
        public bool TemMp3Player { get; set; }
        public string ValorFormatado
        {
            get
            {
                var total = Preco +
                        (TemArCondicionado ? (decimal)Opcionais.ArCondicionado : 0) +
                        (TemFreioAbs ? (decimal)Opcionais.FreioAbs : 0) +
                        (TemMp3Player ? (decimal)Opcionais.Mp3Player : 0);
                return $"Total R$ {total}";
            }
        }
    }
}