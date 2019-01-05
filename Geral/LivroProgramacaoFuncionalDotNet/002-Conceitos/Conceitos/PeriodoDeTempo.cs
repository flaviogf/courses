using System;

namespace Conceitos
{
    public class PeriodoDeTempo
    {
        public DateTime DataInicial { get; }

        public DateTime DataFinal { get; }

        public PeriodoDeTempo(DateTime dataInicial, DateTime dataFinal)
        {
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }

        public static bool VerificaSeDataEstaNoPeriodo(PeriodoDeTempo periodo, DateTime data)
        {
            return data >= periodo.DataInicial && data <= periodo.DataFinal;
        }
    }
}
