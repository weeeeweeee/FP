// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let rec writeList = function
    [] ->
        printf "\n"
        0
    | (head : int)::tail -> 
                       printf "%d " head
                       writeList tail

let isPrime x =
    let rec rp (x:int) (p:int) =
        if p > x then
            true
        elif x % p = 0 then
            false
        else
            rp x (p + 1)
    rp x 2

let pow x y =
    let rec pr x y mult =
        if y = 0 then mult
        else
            pr x (y-1) (mult * x)
    pr x y 1

let makePrimeList x =
    let rec mprl number prime degree =
        if prime <= number then
            let primeInDegree = pow prime degree
            if (number >= primeInDegree) && (isPrime prime) then
                if (number % primeInDegree = 0) then
                    prime::(mprl number prime (degree+1))
                else
                    mprl number prime (degree+1)
            else
                mprl number (prime+1) 1
        else
            []

    mprl x 2 1

let rec fr x =
    if x <= 2 then
        1
    else
        (fr (x-1)) + (fr (x-2))

let fib x =
    let rec fr x y last =
        if x = 1 then
            y
        else
            fr (x - 1) (y + last) y
    fr x 1 0
        

[<EntryPoint>]
let main argv =
    let rec f x y =
        if x < y then
            printf "%d\n" (fib x)
        else
            exit(-1)
        f (x + 1) y
    f 1 100
    0