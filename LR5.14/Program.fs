// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let f x (func : int -> int -> int) init =
    let rec fr x y (func : int -> int -> int) init = 
        if y > x then init
        else
            let i =
                if x % y = 0 then
                    func y init
                else
                    init
            fr x (y + 1) func i
    fr x 1 func init        

[<EntryPoint>]
let main argv =
    let input = Convert.ToInt32(Console.ReadLine())
    printf "Наибольший делитель: %i\n" (f input (fun x y -> if x > y then x else y) -1)
    printf "Сумма делителей: %i\n" (f input (fun x y -> x + y) 0)
    printf "Произведение делителей: %i\n" (f input (fun x y -> x * y) 1)
    printf "Наименьший делитель: %i\n" (f input (fun x y -> if x < y then x else y) 10)
    printf "Количество делителей: %i\n" (f input (fun x y -> y + 1) 0)
    0