// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       printf "%d " head
                       writeList tail

let f list func =
    let rec fr list func new_list =
        match list with
        | h1::h2::h3::t -> fr t func (new_list@[func h1 h2 h3])
        | h1::h2::t -> fr t func (new_list@[func h1 h2 1])
        | h1::t -> fr t func (new_list@[func h1 1 1])
        | [] -> new_list 
    fr list func []

[<EntryPoint>]
let main argv =
    let list = readData
    writeList (f list (fun x y z -> x + y + z))