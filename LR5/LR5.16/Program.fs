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

let Euler x =
    f x (fun x y -> y + 1) 0

let NOD x y =
    let rec fr x y z =
        if z <= 1 then 1
        else
            if x % z = 0 && y % z = 0 then z
            else fr x y (z - 1)

    fr x y (if x > y then y else x)

[<EntryPoint>]
let main argv =
    printf "%i\n" (Euler 36)
    printf "%i\n" (NOD 12126 3483)
    0