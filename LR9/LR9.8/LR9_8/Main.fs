module LR9_8


open System
open System.Windows.Forms
open System.Windows.Forms
open UI

type StartupForm() as this = 
    inherit Form1()
    do
        let txt = this.textBox1
        this.button1.Click.Add <| fun _ ->
                                        let mass = [|1..12|]
                                        let ret = Array.filter (fun x -> x % 3 = 0) mass
                                        txt.Text <- (ret |> Seq.map string |> String.concat ",")





[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartupForm()
    Application.Run(form)
    0