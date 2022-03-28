// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Дан целочисленный массив и отрезок a..b. Необходимо найти
// элементы, значение которых принадлежит этому отрезку.

let writeList list =
    List.iter (printf "%d ") list
    printf "\n"

let f list a b =
    let checkInterval x =
        x >= a && x <= b
    List.filter checkInterval list

[<EntryPoint>]
let main argv =
    let list = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
    let a = 2
    let b = 8
    writeList (f list a b)
    0