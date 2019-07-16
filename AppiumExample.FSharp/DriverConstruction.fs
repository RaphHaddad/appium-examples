module DriverConstruction

open OpenQA.Selenium.Remote
open OpenQA.Selenium.Appium.Windows

type App = 
    | Calculator
    | Notepad

let constructDriver capability = 
    let capability = new DesiredCapabilities()
    capability.SetCapability("app", @"C:\Windows\System32\notepad.exe")
    new WindowsDriver<WindowsElement>(capability)

let getAutomation app = 
    match app with
    | Calculator -> constructDriver "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App"
    | Notepad -> constructDriver "C:\Windows\System32\notepad.exe"

let closeApp app (driver:WindowsDriver<WindowsElement>) = 
    match app with 
    | Calculator -> driver.CloseApp()
    | Notepad -> driver.CloseApp()