// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let DivTrav x (func : int -> int -> int) init (pred: int -> bool) =     // Traversal of Dividers
    let rec fr x y (func : int -> int -> int) init (pred: int -> bool) = 
        if y > x then init
        else
            let i =
                if x % y = 0 && pred y then
                    func y init
                else
                    init
            fr x (y + 1) func i pred
    fr x 1 func init pred

let check x y =
    let rec fr x y z = 
        if z > x || z > y then true
        else 
            if x % z = 0 && y % z = 0 then false
            else fr x y (z + 1)
    fr x y 2

let CoprimeTrav x (func: int -> int -> int) init (pred: int -> bool) =
    let rec frec x y (func: int -> int -> int) init (pred: int -> bool) =
        if y > x then init
        else
            let i =
                if (check x y) && pred y then
                    func y init
                else
                    init
            frec x (y + 1) func i pred
    frec x 1 func init pred

[<EntryPoint>] 
let main argv =
    
    0
