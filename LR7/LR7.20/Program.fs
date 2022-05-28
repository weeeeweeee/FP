// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System




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

let isVowel (x : char) =
    (x = 'а') || (x = 'и') || (x = 'е') || (x = 'ё') || (x = 'о') || (x = 'у') || (x = 'ы') || (x = 'э') || (x = 'ю') || (x = 'я')

let isLetter (x : char) =
    (x >= 'а' && x <= 'я') || (x >= 'А' && x <= 'Я')

let Difference str =
    let s_str = Seq.permute (fun x -> (x + 1)%(Seq.length str)) str
    let zip_str = Seq.skip 1 (Seq.zip str s_str)
    let func x y =
        if (isLetter (fst y)) && (isLetter (snd y)) then
            if (isVowel (snd y)) && (not (isVowel (fst y))) then
                x + 1
            else if (isVowel (fst y)) && (not(isVowel(snd y))) then
                x - 1
            else x
        else x
    Seq.fold func 0 zip_str

let sortwithdiff str_list : string list =
    Seq.toList (Seq.sortBy Difference str_list)

let input =
    Convert.ToInt32(Console.ReadLine())

let rec readstr lst n =
    if n > 0 then
        readstr (lst@[Console.ReadLine()]) (n-1)
    else
        lst

let readData n =
    readstr [] n

let writeList list =
    List.iter (printf "%s ") list
    printf "\n"

[<EntryPoint>]
let main argv =
    printf "Выберите метод сортировки:\n"
    printf "1. Сортировка в порядке увеличения квадратичного отклонения среднего веса 
    ASCII-кода символа строки от среднего веса ASCII-кода символа первой
    строки\n"
    printf "2. Сортировка в порядке увеличения разницы между количеством сочетаний 
    «гласная-согласная» и «согласная-гласная» в строке\n"
    let f = Convert.ToInt32(Console.ReadLine())
    let func =
        match f with
        1 -> sortwithsd
        |2 -> sortwithdiff
        |_ -> exit(-1)

    printf "Введите количество строк: "
    let n = Console.ReadLine()

    printf "Введите %d строк: \n" (Convert.ToInt32(n))
    let lst = readData (Convert.ToInt32(n))
    writeList (func lst)
    0