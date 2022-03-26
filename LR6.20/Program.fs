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
        if p >= x then
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
    let rec mprl number prime degree result_list =
        if prime <= number then
            let primeInDegree = pow prime degree
            if (number >= primeInDegree) && (isPrime prime) then
                if (number % primeInDegree = 0) then
                    mprl number prime (degree+1) (result_list@[prime])
                else
                    mprl number (prime+1) 1 result_list
            else
                mprl number (prime+1) 1 result_list
        else
            result_list

    mprl x 2 1 []

[<EntryPoint>]
let main argv =
    writeList (makePrimeList 8)
    writeList (makePrimeList 19)
    writeList (makePrimeList 169)
    writeList (makePrimeList 225)
    writeList (makePrimeList 490)
    0