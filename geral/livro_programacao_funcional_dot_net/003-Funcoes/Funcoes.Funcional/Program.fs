open FuncoesAninhadas
open Modulos
open FuncaoAltaOrdem

[<EntryPoint>]
let main argv =
    printfn "Funcoes Aninhadas"

    escreveSeNumeroEhParOuImpar 2
    escreveSeNumeroEhParOuImpar 3

    printfn "Namespaces e Modulos"

    FuncoesDeEscritaDeTexto.escreve "Flávio"
    FuncoesDeEscritaDeNumeros.escreve 21

    printfn "Funcoes Alta Ordem"

    let nomes = 
        [
            "Flávio"
            "Fernando"
            "Fatima"
            "Luis Fernando"
        ]
    escreveNomes nomes

    let numeros =
        [
            10
            20
            30
        ]
    escreveDobroNumeros numeros
    escreveNumerosMultiplicadoPorMultiplicador numeros 3

    0
