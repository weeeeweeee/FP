// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Дан целочисленный массив. Необходимо найти минимальный
// четный элемент.

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let findMin list pred =
    let rec recMin list min =
        match list with
        | [] -> min
        | h::t -> 
            if (pred h) && (h < min) then recMin t h
            else recMin t min

    let rec findFrst list =
        match list with
        | (h : int)::t ->
                if (pred h) then Some(h)
                else (findFrst t)
        | [] -> None

    let first = findFrst list
    match first with
    |Some(a) -> Some(recMin list a)
    |None -> None

let findMinEven list =
    findMin list (fun x -> x % 2 = 0)
    

[<EntryPoint>]
let main argv =
    let lst = readData
    match (findMinEven lst) with
    Some(a) -> 
        printf "%d" a
        0
    |_ -> 
        printf "Произошла ужасная ошибка..."
        0