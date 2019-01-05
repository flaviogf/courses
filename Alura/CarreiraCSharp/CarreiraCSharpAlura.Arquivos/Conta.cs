namespace CarreiraCSharpAlura.Arquivos
{
    public class Conta
    {
        public string Agencia { get; }

        public string Numero { get; }

        public decimal Saldo { get; }

        public string Titular { get; }

        public Conta(string agencia, string numero, decimal saldo, string titular)
        {
            Agencia = agencia;
            Numero = numero;
            Saldo = saldo;
            Titular = titular;
        }

        public override string ToString()
        {
            return $"Conta(Agencia={Agencia}, Numero={Numero}, Saldo={Saldo}, Titular={Titular})";
        }
    }
}
