module Main

open System
open System.Windows.Forms
open System.Windows.Forms
open UI

type StartupForm() as this = 
    inherit Form1()
    do
        let textbox = this.textBox1
        let output = this.textBox2

        let tryparse (str:string) =
            try
                Convert.ToInt32(str)
            with _ ->
                0

        this.button1.Click.Add <| fun _ ->
                                        let lst : int list = textbox.Text.Split (',') 
                                                                |> Array.map (fun x -> x.Trim (' '))
                                                                |> Array.map tryparse |> Array.toList

                                        let sum = List.fold (fun acc el -> acc + el) 0 lst
                                        output.Text <- sum.ToString()

        

[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartupForm()
    Application.Run(form)
    0