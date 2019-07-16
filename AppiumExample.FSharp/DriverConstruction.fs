module DriverConstruction

open OpenQA.Selenium.Remote
open OpenQA.Selenium.Appium.Windows
open System

type App = 
    | Calculator
    | Notepad

let constructDriver capability = 
    let desiredCapability = new DesiredCapabilities()
    desiredCapability.SetCapability("app", capability)
    new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"), desiredCapability)

let getAutomation app = 
    match app with
    | Calculator -> constructDriver "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App"
    | Notepad -> constructDriver "C:\Windows\System32\notepad.exe"

let closeApp app (driver:WindowsDriver<WindowsElement>) = 
    match app with 
    | Calculator -> driver.CloseApp()
    | Notepad -> driver.CloseApp()