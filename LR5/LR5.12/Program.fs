// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System


[<EntryPoint>]
let main argv =
    let read = Console.ReadLine()
    let treat a =
        if a = "F#" || a = "Prolog" then
            "Подлиза.\n"
        else if a = "1С" then
            "Хороший язык, чем-то похож на русский.\n"
        else
            "Ну хотя бы не подлиза.\n"
    let prnt a = printf "%s" a

    (treat >> prnt) read // Работа с использованием оператора суперпозиции

    prnt (treat read)
    0