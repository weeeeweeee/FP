// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System


let check x y =
    let rec fr x y z = 
        if z > x || z > y then true
        else 
            if x % z = 0 && y % z = 0 then false
            else fr x y (z + 1)
    fr x y 2

let f17 x (func: int -> int -> int) init (pred: int -> bool) =
    let rec frec x y (func: int -> int -> int) init (pred: int -> bool) =
        if y > x then init
        else
            let i =
                if not (check x y) && pred y then // модификация здесь. <not check> вместо <check> 
                    func y init
                else
                    init
            frec x (y + 1) func i pred
    frec x 1 func init pred

// ^ - модифицированная функция из 17 задания.
// не смог найти более подходящей функции, ко-
// торую бы не пришлось бы переделывать.

let v1 x =
    f17 x (fun x y -> y + 1) 0 (fun x -> (x % 2 = 0))



[<EntryPoint>]
let main argv =
    printf "%d" (v1 20) // Ответ 10: 2 4 6 8 10 12 14 16 18 20

    0