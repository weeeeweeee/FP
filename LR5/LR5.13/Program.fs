// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let rec mult_up (a : int) : int =
    if a = 0 then 
        1
    else
        let x = a % 10
        let b = a / 10
        x * (mult_up b)

let mult_down (a : int) : int =
    let rec mult_rec a cur_mult =
        if a = 0 then cur_mult
        else mult_rec (a/10) (cur_mult * (a % 10))
    mult_rec a 1

let min_down a : int =
    let rec min_rec x m =
        if x = 0 then m
        else
            let n =
                if x % 10 < m then x % 10
                else m
            min_rec (x/10) n 
    min_rec a 10

let rec min_up (a : int) : int = 
    if a < 10 then a
    else
        let m = min_up (a / 10)
        if a % 10 < m then
            a % 10
        else
            m

let max_down a =
    let rec max_rec x m =
        if x = 0 then
            m
        else
            let n =
                if x % 10 > m then
                    x % 10
                else
                    m
            max_rec (x/10) n

    max_rec a -1

let rec max_up (a : int) : int = 
    if a < 10 then a
    else
        let m = max_up (a / 10)
        if a % 10 > m then
            a % 10
        else
            m

[<EntryPoint>]
let main argv =
    let input : int = Convert.ToInt32(Console.ReadLine())

    printf "Произведение цифр (рекурсия вниз): %i\n" (mult_down input)
    printf "Произведение цифр (рекурсия вверх): %i\n" (mult_up input)
    printf "Минимальная цифра (рекурсия вниз): %i\n" (min_down input)
    printf "Минимальная цифра (рекурсия вверх): %i\n" (min_up input)
    printf "Максимальная цифра (рекурсия вниз): %i\n" (max_down input)
    printf "Максимальная цифра (рекурсия вверх): %i\n" (max_up input)

    0
    