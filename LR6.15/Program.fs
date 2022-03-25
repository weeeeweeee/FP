// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Дан целочисленный массив. Необходимо найти элементы,
// расположенные между первым и вторым максимальным.

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let findMax (list : int list) pred =
    let rec recMax list max max_num num =
        match list with
        | [] -> (max, max_num)
        | h::t ->
            if (pred h) && (h > max) then recMax t h num (num+1)
            else recMax t max max_num (num+1)

    let rec findFrst list num =
        match list with
        | (h : int)::t ->
                if (pred h) then Some(h, num)
                else (findFrst t (num+1))
        | [] -> None

    match findFrst list 0 with
    Some(m, ind) ->
        let (a, b) = recMax list m ind 0
        Some(a, b)
    |None -> None

let TwoMax list =
    let (max1, ind1) =
        match findMax list (fun x -> true) with
        Some(m, i) -> m, i
        |None -> exit(-1)
    let (max2, ind2) = 
        match findMax list (fun x -> x < max1) with
        Some(m, i) -> m, i
        |None -> exit(-2)
    (ind1, ind2)

let IntervalCount a b = abs (b - a) - 1
// Насколько я понял, нужно найти именно
// количество элементов, которые располо-
// жены между первым и вторым максималь-
// ным по индексу. Т.е. если первый макси-
// мальный расположен на 3-м месте, в вто-
// рой - на 8-м, то между ними расположе-
// но 4 элемента (или, если учитывать
// крайние элементы, 6)

[<EntryPoint>]
let main argv =
    let lst = readData
    let (ind1, ind2) = TwoMax lst
    printf "%d\n" (IntervalCount ind1 ind2)
    0