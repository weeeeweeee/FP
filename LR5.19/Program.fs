// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System


let CheckForCoprime x y =
    let rec fr x y z = 
        if z > x || z > y then true
        else 
            if x % z = 0 && y % z = 0 then false
            else fr x y (z + 1)
    fr x y 2

let NotCoprimeTraverse x (func: int -> int -> int) init (pred: int -> bool) =
    let rec frec x y (func: int -> int -> int) init (pred: int -> bool) =
        if y > x then init
        else
            let i =
                if not (CheckForCoprime x y) && pred y then // модификация здесь. <not check> вместо <check> 
                    func y init
                else
                    init
            frec x (y + 1) func i pred
    frec x 1 func init pred
// ^ - модифицированная функция из 17 задания.
// не смог найти более подходящей функции, ко-
// торую бы не пришлось бы переделывать.

let v1 x =
    NotCoprimeTraverse x (fun x y -> y + 1) 0 (fun x -> (x % 2 = 0))

let rec NumberTraverse n f init predicate = 
    if n = 0 then init
    else
        let cifr = n % 10
        let n1 = n / 10
        let acc = f init cifr
        if predicate cifr then NumberTraverse n1 f acc predicate
        else NumberTraverse n1 f init predicate
// ^ - функция из 9 задания

let v2 x =
    NumberTraverse x (fun x y -> if x > y then x else y) -1 (fun x -> x % 3 <> 0)


[<EntryPoint>]
let main argv =
    printf "%d\n" (v1 20) // Ответ 10: 2 4 6 8 10 12 14 16 18 20

    printf "%d\n" (v2 2369) // Ответ, очевидно, 2
    printf "%d\n" (v2 2368) // Ответ 8
    printf "%d\n" (v2 369)  // Ответ -1, сигнализирующий о том, что 
                            // числа, удовлетворяющего условию, нет


    0