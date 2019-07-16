module NotepadTests

open DriverConstruction
open Xunit

let edit text notepad = 
    notepad.Driver.FindElementByClassName("Edit").SendKeys(text)
    notepad

let text notepad =
    notepad.Driver.FindElementByClassName("Edit").Text

[<Fact>]
let ``Does edit`` () =
    let notepad = getAutomation Notepad

    let actual = notepad |>
                 edit "this is test" |>
                 text

    Assert.Equal("this is test", actual)
    closeApp notepad
