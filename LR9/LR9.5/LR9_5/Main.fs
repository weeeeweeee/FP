module Main

open System
open System.Windows.Forms
open System.Windows.Forms
open UI

type StartupForm() as this = 
    inherit Form1()
    do
        let cat1 = "1.png"
        let cat2 = "2.png"
        this.pictureBox1.ImageLocation <- cat2

        let image = this.pictureBox1
        let change _ =
            if image.ImageLocation = cat1 then
                image.ImageLocation <- cat2
            else
                image.ImageLocation <- cat1

        this.button1.Click.Add <| fun _ -> change()

        

[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartupForm()
    Application.Run(form)
    0