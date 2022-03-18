// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let check x y =
    let rec fr x y z = 
        if z > x || z > y then true
        else 
            if x % z = 0 && y % z = 0 then false
            else fr x y (z + 1)
    fr x y 2

let f1 x =
    if x % 2 = 0 then
        (x / 2)
    else
        let rec fr x y count =
            if y > x then count
            else
                if not (check x y) then
                    fr x (y + 2) (count + 1)
                else
                    fr x (y + 2) count
        fr x 6 0    // 2 проверять не нужно, т.к. число нечётное
                    // 4 проверять не нужно, т.к. степень двойки
    
let f2 x =
    let rec fr num max =
        if num = 0 then max
        else
            let digit = num % 10;
            let new_num = num / 10;

            let m = 
                if (digit > max) && (digit % 3 <> 0) then digit
                else max
            fr new_num m
    fr x -1


[<EntryPoint>]
let main argv =
    printf "f1(20) = %i, answer = 10\n" (f1 20) // 2 4 6 8 10 12 14 16 18 20 => 10
    printf "f1(21) = %i, answer = 4\n" (f1 21) // 6 12 14 18 => 4
    printf "f1(33) = %i, answer = 6\n" (f1 33) // 6 12 18 22 24 30 => 6

    printf "\n\n"

    printf "f2(22738) = %i, answer = 8\n" (f2 22738)
    printf "f2(333) = %i, answer = -1\n" (f2 333)
    printf "f2(1210) = %i, answer = 2\n" (f2 1210)


    0