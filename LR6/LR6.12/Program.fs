// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// 3 задание
// Дан целочисленный массив и натуральный индекс (число, меньшее
// размера массива). Необходимо определить является ли элемент по
// указанному индексу глобальным максимумом.

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

let findMax list =
    let rec recMax list max =
        match list with
        | [] -> max
        | h::t -> 
            if h > max then recMax t h
            else recMax t max
    recMax list list.Head

let f list x =
    let rec find list x =
        if x > 0 then
            match list with
            | _::t -> find t (x-1)
        else
            list.Head
    if (find list x) = (findMax list) then
        true
    else
        false
    
[<EntryPoint>]
let main argv =
    let list = readData
    let answer = if (f list 2) then "Да" else "Нет"
    printf "%s" answer
    0