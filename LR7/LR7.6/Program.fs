// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Для введенного списка построить список из элементов, встречающихся
// в исходном более трех раз.

let writeList list =
    List.iter (printf "%d ") list
    printf "\n"

let func list =
    let lst = List.countBy id list
    let lst = List.filter (fun x -> (snd x) > 3) lst
    List.map fst lst

[<EntryPoint>]
let main argv =
    let list = [1; 1; 1; 1; 2; 2; 2; 3; 3; 4; 4; 4; 4; 4; 4; 5; 6]
    writeList (func list)
    0