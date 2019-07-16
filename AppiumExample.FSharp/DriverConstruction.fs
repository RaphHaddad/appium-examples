module DriverConstruction

open OpenQA.Selenium.Remote
open OpenQA.Selenium.Appium.Windows
open System

type AppType = 
    | Calculator
    | Notepad

type App = {
    AppType: AppType
    Driver: WindowsDriver<WindowsElement>
}

let constructDriver capability = 
    let desiredCapability = new DesiredCapabilities()
    desiredCapability.SetCapability("app", capability)
    new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"), desiredCapability)

let getAutomation app = 
    match app with
    | Calculator -> { Driver = constructDriver "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App"; AppType = Calculator }
    | Notepad -> { Driver = constructDriver @"C:\Windows\System32\notepad.exe"; AppType = Notepad }

let closeApp app = 
    match app.AppType with 
    | Calculator -> app.Driver.CloseApp()
    | Notepad -> app.Driver.CloseApp()