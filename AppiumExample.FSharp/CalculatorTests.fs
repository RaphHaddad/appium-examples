module CalculatorTests

open DriverConstruction
open OpenQA.Selenium.Appium.Windows
open OpenQA.Selenium
open Xunit

type operator = 
    | Multiply
    | Equals

let clickButton name (calc:WindowsDriver<WindowsElement>) =
    calc.FindElement(By.Name(name)).Click()
    calc

let clickNumber number calc = 
    match number with
    | 0 -> clickButton "Zero" calc
    | 1 -> clickButton "One" calc
    | 2 -> clickButton "Two" calc
    | 3 -> clickButton "Three" calc
    | 4 -> clickButton "Four" calc
    | 5 -> clickButton "Five" calc
    | 6 -> clickButton "Six" calc
    | 7 -> clickButton "Seven" calc
    | 8 -> clickButton "Eight" calc
    | 9 -> clickButton "Nine" calc

let clickOperator operator calc = 
    match operator with
    | Multiply -> clickButton "Multiply by" calc
    | Equals -> clickButton  "Equals" calc

let result calc = 
    clickOperator Equals calc |> ignore
    (calc.FindElementByAccessibilityId "CalculatorResults").Text.Replace("Display is ","") |>
    double

[<Fact>]
let ``Does calculate 2 x 3`` () =
    let calc = getAutomation Calculator
    let result = calc |>
                 clickNumber 2 |>
                 clickOperator Multiply |>
                 clickNumber 3 |>
                 result

    Assert.Equal(6.0, result)
    closeApp Calculator calc
