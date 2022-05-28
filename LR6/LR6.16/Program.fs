// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let findMax (list : int list) predNum =
    let rec recMax list max max_num num =
        match list with
        | [] -> (max, max_num)
        | h::t ->
            if (predNum num) && (h > max) then recMax t h num (num+1)
            else recMax t max max_num (num+1)

    let rec findFrst list num =
        match list with
        | (h : int)::t ->
                if (predNum num) then Some(h, num)
                else (findFrst t (num+1))
        | [] -> None

    match findFrst list 0 with
    Some(m, ind) ->
        let (a, b) = recMax list m ind 0
        Some(a, b)
    |None -> None

let findMaxInInterval list a b =
    match findMax list (fun x -> x >= a && x <= b) with
    Some(a, _) -> a
    |None -> -1 // Неправильно введён интервал

[<EntryPoint>]
let main argv =
    let lst = readData
    printf "%d" (findMaxInInterval lst 2 4)
    0