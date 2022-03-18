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
    
[<EntryPoint>]
let main argv =
    printf "%i\n" (f1 20) // 2 4 6 8 10 12 14 16 18 20 => 10
    printf "%i\n" (f1 21) // 6 12 14 18 => 4
    printf "%i\n" (f1 33) // 6 12 18 22 24 30 => 6
    0