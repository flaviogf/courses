using System;
using System.IO;
using static System.Console;

namespace CarreiraCSharpAlura.Exceptions
{
    public class LeitorDeArquivo : IDisposable
    {
        public LeitorDeArquivo()
        {

        }

        public void Leh()
        {
            WriteLine("Lendo");
            throw new IOException();
        }

        public void Dispose()
        {
            WriteLine("Limpando Memoria");
        }
    }

    public class OperacaoFinanceiraInvalidaException : Exception
    {
        public string NomeOperacao { get; }

        public OperacaoFinanceiraInvalidaException()
        {

        }

        public OperacaoFinanceiraInvalidaException(string message) : base(message)
        {

        }

        public OperacaoFinanceiraInvalidaException(string message, string nomeOperacao) : this(message)
        {
            NomeOperacao = nomeOperacao;
        }
    }

    public class SaldoInsuficienteException : OperacaoFinanceiraInvalidaException
    {
        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(string message) : base(message)
        {

        }

        public SaldoInsuficienteException(string message, string nomeOperacao) : base(message, nomeOperacao)
        {

        }
    }

    public class ContaCorrente
    {
        public int Agencia { get; }

        public int Numero { get; }

        public decimal Saldo { get; private set; }

        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException($"Parametro {nameof(agencia)} invalido", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException($"Parametro {nameof(numero)} invalido", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;
        }

        public void Saca(decimal valor)
        {
            if (Saldo - valor < 0)
            {
                throw new SaldoInsuficienteException("Saldo insuficiente", nameof(Saca));
            }

            Saldo -= valor;
        }

        public void Deposita(decimal valor)
        {
            if (valor < 0)
            {
                throw new OperacaoFinanceiraInvalidaException("Valor de saque inválido", nameof(Deposita));
            }

            Saldo += valor;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            TestaException4();
            // TestaException1();
            // TestaException2();
            // TestaException3();
            // TestaTratamento1();
            // TestaTratamento2();
        }

        private static void TestaException4()
        {
            LeitorDeArquivo leitor2 = null;

            try
            {
                leitor2 = new LeitorDeArquivo();
                leitor2.Leh();
            }
            catch (IOException e)
            {
                WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (leitor2 != null)
                {
                    leitor2.Dispose();
                }
            }
        }

        private static void TestaException3()
        {
            using (var leitor = new LeitorDeArquivo())
            {
                leitor.Leh();
            }
        }

        private static void TestaException2()
        {
            var conta = new ContaCorrente(100, 100);
            try
            {
                conta.Deposita(100);
                conta.Saca(50);
                WriteLine(conta.Saldo);
                conta.Saca(100);
                conta.Deposita(-500);
            }
            catch (SaldoInsuficienteException e)
            {
                WriteLine(e.NomeOperacao);
            }
            catch (OperacaoFinanceiraInvalidaException e)
            {
                WriteLine(e.NomeOperacao);
            }
        }

        private static void TestaException1()
        {
            try
            {
                var conta = new ContaCorrente(0, 0);
            }
            catch (ArgumentException e)
            {
                WriteLine(e.ParamName);
                WriteLine(e.Message);
            }
        }

        private static void TestaTratamento2()
        {
            try
            {
                WriteLine(Divide(10, 0));
            }
            catch (DivideByZeroException)
            {
                WriteLine("Exeção tratada");
            }
        }

        private static void TestaTratamento1()
        {
            try
            {
                string teste = null;
                WriteLine(teste.ToUpper());
                WriteLine(Divide(10, 0));
            }
            catch (NullReferenceException e)
            {
                WriteLine(e.Message);
                WriteLine(e.StackTrace);
            }
            catch (DivideByZeroException e)
            {
                WriteLine(e.Message);
                WriteLine(e.StackTrace);
            }
        }

        public static int Divide(int numero, int divisor)
        {
            return numero / divisor;
        }
    }
}
