module Calculadora

let quadrado numero = numero * numero

let somaQuadradoDezPrimeirosNumeros =
    [1..10] 
    |> List.map quadrado
    |> List.sum
