let soma = (+)

let somaCom3 = soma 3

let dobraValoresDeUmaListaSemPipeLine =
    let lista = [1..10]
    let itensMaioresQue5 = List.filter(fun x -> x > 5) lista
    List.map(fun x -> x * 2) itensMaioresQue5

// let (|>) parametro funcao = funcao parametro

let dobraValoresDeUmaListaComPipeLine =
    [1..10]
    |> List.filter(fun x -> x > 5)
    |> List.map(fun x -> x * 2)

//let (<|) funcao parametro = funcao (parametro)

let exemploInverso num1 num2 =
    (fun x -> x + 10) <| num1 * num2

let numeroImparOperadorInverso valor =
    let numeroPar numero = numero % 2 = 0
    not <| numeroPar valor

let convertBoolParaTexto valor =
    if valor then "Sim" else "Não"

let ehPar numero = numero % 2 = 0

let compor fun1 fun2 valor =
    fun1(fun2(valor))

let verificaSeONumeroEhPar =
    ehPar >> convertBoolParaTexto

[<EntryPoint>]
let main argv =
    printfn "Função soma"
    printfn "%i" (somaCom3 2)
    printfn "Soma sem pipeline"
    List.iter (printfn "%i") dobraValoresDeUmaListaSemPipeLine
    printfn "Soma com pipeline"
    List.iter (printfn "%i") dobraValoresDeUmaListaComPipeLine
    printfn "Exemplo operador inverso"
    printfn "%i" (exemploInverso 1 2)
    printfn "%b" (numeroImparOperadorInverso 2)
    printfn "%b" (numeroImparOperadorInverso 3)
    printfn "Composição"
    printfn "%s" (convertBoolParaTexto true)
    printfn "%b" (ehPar 1)
    printfn "10 é par: %s" (compor convertBoolParaTexto ehPar 10)
    printfn "10 é par: %s" (verificaSeONumeroEhPar 10)
    printfn "10 é par: %s" ((ehPar >> convertBoolParaTexto) 10)
    0
