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

    

let DivTraverse x (func : int -> int -> int) init =
    let rec fr x y (func : int -> int -> int) init = 
        if y > x then init
        else
            let i =
                if x % y = 0 then
                    func y init
                else
                    init
            fr x (y + 1) func i
    fr x 2 func init  
// ^ - функция из 14 задания - обход делителей числа
// (немного модифицированная, чтобы обход начинался
// не с 1, а с 2, потому что иначе минимальный дели-
// тель всегда будет равен 1, а числа, которое бы не
// делилось на 1, не существует)

let v3 x =
    let min = DivTraverse x (fun x y -> if x < y then x else y) x
    let max = NotCoprimeTraverse x (fun x y -> if x > y then x else y) -1 (fun x -> x % min <> 0)
    let sum = NumberTraverse x (fun x y -> x + y) 0 (fun x -> x < 5) 
    sum * max


[<EntryPoint>]
let main argv =
    printf "%d\n" (v1 20) // Ответ 10: 2 4 6 8 10 12 14 16 18 20

    printf "%d\n" (v2 2369) // Ответ, очевидно, 2
    printf "%d\n" (v2 2368) // Ответ: 8
    printf "%d\n" (v2 369)  // Ответ: -1, сигнализирующий о том, что 
                            // числа, удовлетворяющего условию, не
    
    printf "%d\n" (v3 225)  // Ответ: 3 - наименьший делитель,
                            // 220 - наибольшее невзаимнопростое
                            // 220 * 4 = 880
    0