open PeriodoDeTempo
open System

[<EntryPoint>]
let main argv =
    let periodo = {
        DataInicial = DateTime.Parse "01/10/2018"
        DataFinal = DateTime.Parse "01/11/2018"
    }

    let datas =
        [|
            DateTime.Parse "02/10/2018"
            DateTime.Parse "12/10/2018"
            DateTime.Parse "02/11/2018"
        |]

    for data in datas do
        let resultado = verificaSeDataEstaNoPeriodo periodo data
        printfn "%b" resultado
    0
