// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Дан целочисленный массив. Вывести индексы массива в том
// порядке, в котором соответствующие им элементы образуют
// убывающую последовательность.

let writeList list =
    List.iter (printf "%d ") list
    printf "\n"

let func (list : int list) =
    let indlist = List.indexed list
    let sortlist = List.sortByDescending snd indlist
    List.map fst sortlist

[<EntryPoint>]
let main argv =
    let list = [4;2;1;3;5]
    writeList (func list)
    0