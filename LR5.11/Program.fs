// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

[<EntryPoint>]
let main argv =
    let z = Console.ReadLine()
    if z = "F#" || z = "Prolog" then
        printf "Подлиза"
    else if z = "1С" then
        printf "Хороший язык, чем-то напоминает русский."
    else
        printf "Ну хотя бы не подлиза..."
    0