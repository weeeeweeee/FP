// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Создать функцию фильтр для массива А [1; 2; 3; 4; 5; 6; 7;
// 8; 9; 10; 11; 12] в котором элементы будут делиться на 3 без
// остатка

let writeArray arr =
    Array.iter (printf "%d ") arr
    printf "\n"

let func arr =
    Array.filter (fun x -> x % 3 = 0) arr

[<EntryPoint>]
let main argv =
    let arr = [|1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12|]
    let new_arr = func arr
    writeArray new_arr
    0