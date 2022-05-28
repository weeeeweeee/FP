// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System


// Дан целочисленный массив. Необходимо найти элементы,
// расположенные между первым и последним максимальным.

// Я так понимаю, первый максимальный - это просто максимальный
// а последний максимальный - это минимальный.

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

let findMax list =
    let rec fm list max max_num num =
        match list with
        h::t ->
            if h > max then fm t h num (num+1)
            else fm t max max_num (num+1)
        |[] -> (max, max_num)
    fm list list.Head 0 0

let findMin list =
    let rec fm list min min_num num =
        match list with
        h::t ->
            if h < min then fm t h num (num+1)
            else fm t min min_num (num+1)
        |[] -> (min, min_num)
    fm list list.Head 0 0

let find list predNum =
    let rec rf list num new_list =
        match list with
        h::t -> 
            if (predNum num) then
                rf t (num+1) (new_list@[h])
            else 
                rf t (num+1) new_list
        |[] -> new_list
    rf list 0 []

let findInInterval list a b =
    find list (fun x -> x > a && x < b)

[<EntryPoint>]
let main argv =
    let lst = readData
    let (_, i1) = findMax lst
    let (_, i2) = findMin lst
    let (ind1, ind2) =
        if i1 < i2 then (i1, i2)
        else (i2, i1)

    writeList (findInInterval lst ind1 ind2)
    Console.ReadKey()
    0