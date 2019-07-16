using System;
using System.Linq;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace AppiumExample.Apps
{
    public class Notepad : WindowsDriver<WindowsElement>
    {
        public Notepad() : base(new Uri("http://127.0.0.1:4723"), ConstructCapabilities())
        {

        }

        public void EditText(string text)
        {
            FindElementByClassName("Edit").SendKeys(text);
        }

        public new void Close()
        {
            CloseApp();
            var button = FindElementsByClassName("CCPushButton").First(b => b.Text.Equals("Don't Save"));
            button.Click();
        }

        private static DesiredCapabilities ConstructCapabilities()
        {
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", @"C:\Windows\System32\notepad.exe");
            return appCapabilities;
        }
    }
}
