using System;
using static Conceitos.PeriodoDeTempo;

namespace Conceitos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dataInicial = DateTime.Parse("10/10/2018");
            var dataFinal = DateTime.Parse("10/11/2018");
            var periodo = new PeriodoDeTempo(dataInicial, dataFinal);

            var datas = new DateTime[]
            {
                DateTime.Parse("11/10/2018"),
                DateTime.Parse("15/10/2018"),
                DateTime.Parse("11/11/2018")
            };

            foreach (var it in datas)
            {
                Console.WriteLine(VerificaSeDataEstaNoPeriodo(periodo, it));
            }
        }
    }
}
