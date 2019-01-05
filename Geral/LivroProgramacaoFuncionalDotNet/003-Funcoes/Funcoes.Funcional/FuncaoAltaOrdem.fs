module FuncaoAltaOrdem

let executaAcaoSobreLista lista acao =
    lista
    |> List.iter acao

let escreveNome nome = 
    printfn "Nome: %s" nome

let escreveNomes nomes = 
    executaAcaoSobreLista nomes escreveNome

let escreveDobro numero = 
    printfn "Dobro: %i" (numero * 2)

let escreveNumeroMultiplicadoPeloMultiplicador multiplicador numero =
    printfn "%i x %i = %i" numero multiplicador (numero * multiplicador)

let escreveNumeroMultiplicadoPeloMultiplicadorCurrying multiplicador =
    fun numero ->
        printfn "%i x %i = %i" numero multiplicador (numero * multiplicador)

let escreveDobroNumeros numeros =
    executaAcaoSobreLista numeros (escreveNumeroMultiplicadoPeloMultiplicador 2)

let escreveNumerosMultiplicadoPorMultiplicador numeros multiplicador =
    executaAcaoSobreLista numeros (escreveNumeroMultiplicadoPeloMultiplicadorCurrying multiplicador)
