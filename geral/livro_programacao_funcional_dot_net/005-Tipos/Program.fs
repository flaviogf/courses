let verificaSeNumeroEhPar numero =
    if numero % 2 = 0 then "Sim" else "Não"

let verificaSeNumeroEhPar2 numero =
    match numero % 2 = 0 with
    | true -> "Sim"
    | false -> "Não"

let verificaSeEhParOuZero numero =
    match numero with
    | 0 -> "Zero"
    | numero when numero % 2 = 0 -> "Par"
    | _ -> "Impar"

let fatorial numero =
    let mutable acumulador = numero
    for i = numero - 1 downto 1 do
        acumulador <- acumulador * i
    acumulador

let rec fatorial2 numero =
    match numero with
    | 0 | 1 -> 1
    | 2 -> 2
    | _ -> numero * fatorial2(numero - 1)

// Apelidos
type Numero = int
type OperacaoMatematica = int -> int -> int
type Tupla = int * string

let inverteTupla (x, y) =
    y, x

type InteiroBool = {inteiro: int; bool: bool}

type InteiroOuBool =
    | Inteiro of int
    | Bool of bool

type Resultado =
    | Sucesso
    | Falha

[<Measure>] type km
[<Measure>] type h
[<Measure>] type m
[<Measure>] type s

[<EntryPoint>]
let main argv =
    printfn "Pattern Matching"
    printfn "%s" (verificaSeNumeroEhPar 10)
    printfn "%s" (verificaSeNumeroEhPar2 10)
    printfn "%s" (verificaSeEhParOuZero 10)
    printfn "%i" (fatorial 5)
    printfn "%i" (fatorial2 5)
    printfn "Tipos"
    let tupla1: Tupla = 1, "teste"
    let numero, nome = tupla1
    printfn "%i, %s" numero nome
    let nome, numero = inverteTupla tupla1
    printfn "%i, %s" numero nome
    let inteiroBool1 = {inteiro = 1; bool = false}
    printfn "%i %b" inteiroBool1.inteiro inteiroBool1.bool
    let resultado = Sucesso
    printfn "%A" Sucesso
    let stringOpcional = Some "flavio"
    match stringOpcional with
        | Some texto -> printfn "Texto %s" texto
        | None -> printfn "Sem Valor"

    let quilometro = 20.0<km>
    let metro = 200.0<m>
    let fatorConversao = 0.001<km/m>
    let metrosConvertidos = metro * fatorConversao
    printf "%A" (metrosConvertidos + quilometro) 
    0
