module FuncoesAninhadas

let escreveSeNumeroEhParOuImpar numero =
    let ehPar() = numero % 2 = 0
    let escreveNumeroPar() = printfn "O numero %i é par" numero
    let escreveNumeroImpar() = printfn "O numero %i é impar" numero
    if ehPar() then escreveNumeroPar() else escreveNumeroImpar()
