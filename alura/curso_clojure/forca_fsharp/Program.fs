open System

let mult2 (x: float) = x * 2.0


let pow3 (x: float) = x * 2.0 ** x


let endGame () = printfn "End Game"


let missinWords (words: string) (hits: Set<string>) = 
    Seq.toList words
        |> List.filter (fun x -> not(hits.Contains(x.ToString())))


let hitsAllWords (words: string) (hits: Set<String>) =
    List.isEmpty (missinWords words hits)


let rec game (numberLife: int) (words: string) (hits: Set<string>) =
    if numberLife = 0 then
        endGame ()
    elif (hitsAllWords words hits) then
        printfn "Win"
    else
        printfn "Play Game"
        game (numberLife - 1) words hits


[<EntryPoint>]
let main argv =
    
    printfn "%f" (mult2 10.0)
    printfn "%f" (pow3 2.0)

    let words = "test"

    let hits = set ["t"; "e"; "s";]

    game 5 words hits

    0 // return an integer exit code
