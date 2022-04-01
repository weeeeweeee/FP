// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Console.ReadLine()
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let writeList list =
    List.iter (printf "%s ") list
    printf "\n"

let ASCIIAver (str : string) =              // Среднее ASCII-значение
    Seq.averageBy (fun x -> float x) str

let ASCIICount (str:string) x =             // Количество символов с одним ASCII-кодом
    Seq.fold (fun s y -> if y = x then s + 1 else s) 0 str

let Averageforx (str:string) x =            // Среднее количество символов с одним ASCII-кодом
    float (ASCIICount str x) / float (String.length str)

let SquareDeviation str1 str2 =             // Что-то страшное...
    let aver1 = ASCIIAver str1
    let len2 = String.length str2
    let averageinstr2 = Averageforx str2
    let D : float = Seq.fold (fun s x -> s + (averageinstr2 x)*((float x) - aver1)) (float 0) str2
    sqrt D

let sortwithsd str_list : string list =   // Собственно, сортировка
    Seq.toList (Seq.sortBy (fun x -> SquareDeviation (Seq.head str_list) x) str_list)


[<EntryPoint>]
let main argv =
    
    0