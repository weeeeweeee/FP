// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let isPalyndrom str =
    let rev_str = Seq.rev str
    Seq.forall2 (fun x y -> x = y) str rev_str

(*let DistSpaces (str:string) = 
    let rec Dist (str:char list) (lastWasSpace : bool) (newstr:char list) =
        match str with
        h::t ->
            if lastWasSpace && h = ' ' then
                Dist t true newstr
            else if not lastWasSpace && h = ' ' then
                Dist t true newstr@[h]
            else
                Dist t false newstr@[h]
        |[] ->
            if lastWasSpace then
                Seq.toList (Seq.rev (Seq.skip 1 (Seq.rev newstr)))
            else
                newstr

    Seq.cast<char> (Dist (Seq.toList str) false [])*)

let WordCount str =
    Seq.fold (fun s x -> if x = ' ' then s + 1 else s) 1 str

let DiffNum str =
    Seq.length (Seq.distinct str)

[<EntryPoint>]
let main argv =
    
    0