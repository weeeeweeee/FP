// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let isPalyndrom str =
    let rev_str = Seq.rev str
    Seq.forall2 (fun x y -> x = y) str rev_str


[<EntryPoint>]
let main argv =
    
    0