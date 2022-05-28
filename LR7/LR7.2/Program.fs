// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Дан целочисленный массив и интервал a..b. Необходимо найти
// количество элементов в этом интервале.



let count list a b =
    let checkInterval x =
        x >= a && x <= b
    List.fold (fun s x -> if checkInterval x then s + 1 else s ) 0 list

[<EntryPoint>]
let main argv =
    let list = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
    let a = 4
    let b = 9
    printf "%d " (count list a b) 
    0