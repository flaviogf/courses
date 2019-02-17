module PeriodoDeTempo

open System

type Periodo = {
    DataInicial: DateTime
    DataFinal: DateTime
}

let verificaSeDataEstaNoPeriodo (periodo: Periodo) (data: DateTime) =
    data >= periodo.DataInicial && data <= periodo.DataFinal
