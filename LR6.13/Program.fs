// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Дан целочисленный массив. Вывести индексы массива в том
// порядке, в котором соответствующие им элементы образуют
// убывающую последовательность.

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let findMax list pred =
    let rec recMax list max =
        match list with
        | [] -> max
        | h::t -> 
            if (pred h) && (h > max) then recMax t h
            else recMax t max

    let rec findFrst list =
        match list with
        | (h : int)::t ->
                if (pred h) then Some(h)
                else (findFrst t)
        | [] -> None

    let first = findFrst list
    match first with
    |Some(a) -> Some(recMax list a)
    |None -> None

let findIndex list el =
    let rec fir list el num =
        match list with
        |h::t ->
                if el = h then num
                else fir t el (num + 1)
        |[] -> -1
    fir list el 0

let srt list =
    let max = 
        match findMax list (fun x -> true) with
        |Some(a) -> a
        |None -> exit(-1)

    let rec fr list m new_list = 
        let max = findMax list (fun x -> x < m)
        match max with
        |Some(a) -> fr list a (new_list@[a])
        |None -> new_list

    max::(fr list max [])

let f list =
    let srt_list = srt list
    let rec procss list1 list2 =
        match list1 with
        | h::t -> 
                (findIndex list2 h)::(procss t list2)
        | [] -> []
    procss srt_list list

[<EntryPoint>]
let main argv =
    writeList (f readData)
    0