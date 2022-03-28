// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Дан целочисленный массив. Необходимо найти два наибольших
// элемента.

let TwoMax list =
    let frstmax = List.max list
    let listwof = List.filter (fun x -> x < frstmax) list
    let scndmax = List.max listwof
    (frstmax, scndmax)

[<EntryPoint>]
let main argv =
    let list = [2; 3; 6; 2; 4; 7; 4; 6; 73; 1; 10]
    let max = TwoMax list
    printf "%d, %d " (fst max) (snd max)
    0