// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Дан целочисленный массив и интервал a..b. Необходимо найти
// количество элементов в этом интервале.

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let func list a b =
    let rec fr list a b count =
        match list with
        | h::t -> 
                if h >= a && h <= b then 
                    fr t a b (count + 1)
                else
                    fr t a b count
        |[] -> count
    fr list a b 0


[<EntryPoint>]
let main argv =
    let lst = readData
    printf "%d" (func lst 3 8)
    0