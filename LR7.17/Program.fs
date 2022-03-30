// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Для введенного списка построить новый с элементами вида (a,b,c), где
// a<b<c образуют Пифагорову тройку. 

let writeList list =
    let print x =
        match x with
        (s1, s2, s3) -> printf "(%d, %d, %d)\n" s1 s2 s3
    List.iter print list

let sortTuple (x, y, z) =
    let list = [x; y; z]
    let sorted_list = List.sort list
    match sorted_list with
    h1::h2::h3::t -> 
        (h1, h2, h3)
    |_ -> exit(-1) // не будет такой ошибки никогда, но всё же
    

let PythagorasCheck (x, y, z) =
    x*x + y*y = z*z 

let func list =
    let s2 = List.allPairs list list
    let s3 = List.allPairs list s2
    let Extract (x : (int*(int*int))) =
        let (a, b, c) = fst x, (fst (snd x)), (snd (snd x))
        (a, b, c)
    let sorted = List.map sortTuple (List.map Extract s3)
    List.filter PythagorasCheck (List.distinct sorted)

[<EntryPoint>]
let main argv =
    let list = [3; 4; 5; 7; 8; 12; 13; 15; 17; 35; 37]
    // (3, 4, 5); (5, 12, 13); (8; 15; 17); (12; 35; 37)
    writeList (func list)
    0