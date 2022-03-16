// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let check x y =
    let rec fr x y z = 
        if z > x || z > y then true
        else 
            if x % z = 0 && y % z = 0 then false
            else fr x y (z + 1)
    fr x y 2

let f x (func: int -> int -> int) init =
    let rec frec x y (func: int -> int -> int) init =
        if y > x then init
        else
            let i =
                if (check x y) then
                    func y init
                else
                    init
            frec x (y + 1) func i
    frec x 1 func init 

[<EntryPoint>]
let main argv =
    let input : int = Convert.ToInt32(Console.ReadLine())

    printf "Наибольшее взаимно простое число: %i\n" (f input (fun x y -> if x > y then x else y) -1)
    printf "Сумма взаимно простых чисел: %i\n" (f input (fun x y -> x + y) 0)
    printf "Произведение взаимно простых чисел: %i\n" (f input (fun x y -> x * y) 1)
    printf "Наименьшее взаимно простое число: %i\n" (f input (fun x y -> if x < y then x else y) 10)
    printf "Количество взаимно простых чисел: %i\n" (f input (fun x y -> y + 1) 0)
    0