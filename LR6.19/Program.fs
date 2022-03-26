// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Дан целочисленный массив. Необходимо вывести вначале его
// положительные элементы, а затем - отрицательные.

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
                       printf "%d " head
                       writeList tail

let find list pred =
    let rec rf list new_list =
        match list with
        h::t ->
            if (pred h) then
                rf t (new_list@[h])
            else
                rf t new_list
        |[] -> new_list
    rf list []

let findPositive list =
    find list (fun x -> x > 0)
let findNegative list =
    find list (fun x -> x < 0)

[<EntryPoint>]
let main argv =
    let lst = readData
    writeList ((findPositive lst) @ (findNegative lst))