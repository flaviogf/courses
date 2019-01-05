namespace Modulos

[<RequireQualifiedAccess>]
module FuncoesDeEscritaDeTexto =
    let escreve texto = printfn "Texto: %s" texto

[<RequireQualifiedAccess>]
module FuncoesDeEscritaDeNumeros =
    let escreve numero = printfn "Numero: %i" numero
