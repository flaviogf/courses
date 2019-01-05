module Persistencia

open Wrappers

type Tabela<'a> = {
    Arquivo: string
    Dados: 'a list
}

let salva tabela =
    Json.serializa tabela.Dados
    |> File.escreve tabela.Arquivo
    tabela
