namespace Wrappers

module Json =
    open Newtonsoft.Json

    let serializa objeto =
        JsonConvert.SerializeObject(objeto)

    let desserializa<'a> json =
        JsonConvert.DeserializeObject<'a>(json)

module File =
    open System.IO

    let escreve arquivo conteudo =
        File.WriteAllText(arquivo, conteudo)

    let leh arquivo =
        File.ReadAllText(arquivo)

    let existe arquivo =
        File.Exists arquivo
