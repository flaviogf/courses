type IPessoa =
    abstract member Nome: string
    abstract member Sobrenome: string
    abstract member NomeCompleto: string

type Pessoa (nome: string, sobrenome: string, idade: int) =
    member __.Nome = nome
    member __.Idade = idade
    member __.Sobrenome = sobrenome
    member __.Maioridade with get() = __.Idade >= 18

    override __.ToString() =
        sprintf "Pessoa[Nome=%s, Idade=%i, Maioridade=%b]" __.Nome __.Idade __.Maioridade

    interface IPessoa with
        member __.Nome = nome
        member __.Sobrenome = sobrenome
        member __.NomeCompleto with get() = sprintf "%s %s" __.Nome __.Sobrenome

 type Cliente(nome: string, sobrenome: string, idade: int, ativo: bool) =
    inherit Pessoa(nome, sobrenome, idade)

    member val Ativo = ativo with get, set

    override __.ToString() =
        sprintf "Pessoa[Nome=%s, Idade=%i, Maioridade=%b, Ativo=%b]" __.Nome __.Idade __.Maioridade __.Ativo
    

[<EntryPoint>]
let main argv =
    let p1 = Pessoa("Flavio", "Fernandes", 21)
    printfn "%A" p1
    printfn "%s" (p1 :> IPessoa).NomeCompleto
    let c1 = Cliente("Fernando", "Fernandes", 24, true)
    printfn "%A" c1
    printfn "%s" (c1 :> IPessoa).NomeCompleto
    c1.Ativo <- false
    printfn "%A" c1
    printfn "%s" (c1 :> IPessoa).NomeCompleto
    0
