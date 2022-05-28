module LR9_7

open System
open System.Windows.Forms
open System.Windows.Forms
open UI

type StartupForm() as this = 
    inherit Form1()
    do
        let cmbbx = this.comboBox2
        let combolist = [("Январь", "Зима");("Февраль", "Зима");
                         ("Март", "Весна");("Апрель", "Весна");
                         ("Май", "Весна");("Июнь", "Лето");
                         ("Июль", "Лето");("Август", "Лето");
                         ("Сентябрь", "Осень");("Октябрь", "Осень");
                         ("Ноябрь", "Осень");("Декабрь", "Зима")]
        cmbbx.DataSource <- new BindingSource(combolist, null)
        cmbbx.DisplayMember <- "Item1"
        
        this.button1.Click.Add <| fun _ ->
                                        let parse (str:string) =
                                            let u = str.Trim ('(', ')',' ')
                                            let T = u.Split ','
                                            (T.[0], T.[1])
                                        if cmbbx.SelectedItem <> null then
                                            match parse (cmbbx.SelectedItem.ToString()) with
                                            | (_, b) -> MessageBox.Show(b)  
                                        else
                                            MessageBox.Show("Выберите Месяц!")
                                        |> ignore

[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartupForm()
    Application.Run(form)
    0
