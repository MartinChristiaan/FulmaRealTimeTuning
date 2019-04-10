module App.View

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.FontAwesome


type Model =
    { Value : float }

type Msg =
    | ChangeValue of float

let init _ = { Value = 10.0 }, Cmd.none

let private update msg model =
    match msg with
    | ChangeValue newValue ->
        { model with Value = newValue }, Cmd.none
let changeWithFloat (value:string) =
  float value|>ChangeValue

let private view model dispatch =
    Hero.hero [ Hero.IsFullHeight ]
        [ Hero.body [ ]
            [ Container.container [ ]
                [ Columns.columns [ Columns.CustomClass "has-text-centered" ]
                    [ Column.column [ Column.Width(Screen.All, Column.IsOneThird)
                                      Column.Offset(Screen.All, Column.IsOneThird) ]
                        [ Image.image [ Image.Is128x128
                                        Image.Props [ Style [ Margin "auto"] ] ]
                            [ img [ Src "assets/fulma_logo.svg" ] ]
                          Field.div [ ]
                            [ Label.label [ ]
                                [ str "Enter your name" ]
                              Control.div [ ]

                                [ Input.text [ Input.Type Input.IInputType.Number
                                               Input.OnChange (fun ev -> dispatch (changeWithFloat ev.Value))
                                               Input.Value (model.Value.ToString())
                                               Input.Props [ AutoFocus true ] ]
                                  button[] [str "MyButton"] ] ]

                          Content.content [ ]
                            [ str "Hello, "
                              str " "
                              Icon.faIcon [ ]
                                [ Fa.icon Fa.I.SmileO ] ] ] ] ] ] ]

open Elmish.React
open Elmish.Debug
open Elmish.HMR

Program.mkProgram init update view
#if DEBUG
|> Program.withHMR
#endif
|> Program.withReactUnoptimized "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
