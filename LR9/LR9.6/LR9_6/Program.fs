open System
open System.Windows
open System.Windows.Markup
open System.Windows.Controls
open System.Windows.Media
open System.Windows.Media.Imaging


let mwXaml = "
<Window  
    xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' 
    Title='F# Windows App' Height='300' Width='455.715'>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height='3*'></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>
        <Image Name='image' Grid.Row='0'></Image>
        <Button Name='button' Grid.Row='1' Margin='150,20,150,20'>НЕ НАЖИМАТЬ</Button>
    </Grid>
</Window>
    "
let getWindow(mwXaml) =
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window

let win = getWindow(mwXaml)

let image = win.FindName("image") :?> Image
let button = win.FindName("button") :?> Button

let klee1 = new BitmapImage()
let klee2 = new BitmapImage()

klee1.BeginInit()
klee2.BeginInit()

klee1.UriSource <- new Uri(@"F:\1.png")
klee2.UriSource <- new Uri(@"F:\2.png")

klee1.EndInit()
klee2.EndInit()

image.Source <- klee1

let mutable n = false

let change e =
    if n = false then
        image.Source <- klee2
        n <- true
    else
        image.Source <- klee1
        n <- false

button.Click.Add(fun e -> 
                    if n = false then
                        image.Source <- klee2
                        n <- true
                    else
                        image.Source <- klee1
                        n <- false)

[<EntryPoint>]
[<STAThread>] 
let main argv =
    ignore <| (new Application()).Run win
    0
