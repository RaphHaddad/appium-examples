using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace AppiumExample.Apps
{
    public class Calculator : WindowsDriver<WindowsElement>
    {
        public Calculator() : base(new Uri("http://127.0.0.1:4723"), ConstructCapabilities())
        {
            
        }

        private static DesiredCapabilities ConstructCapabilities()
        {
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", @"Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            return appCapabilities;
        }

        public void ClickNumber(Numbers number)
        {
            var numb = number.ToString();
            FindElement(By.Name(numb)).Click();
        }

        public void ClickMultiply()
        {
            FindElement(By.Name("Multiply by")).Click();
        }
        public void ClickEquals()
        {
            FindElement(By.Name("Equals")).Click();
        }

        public new void Close()
        {
            CloseApp();
        }

        public double Result()
        {
            return double.Parse(FindElementByAccessibilityId("CalculatorResults")
                .Text
                .Replace("Display is ", ""));
        }
    }

    public enum Numbers
    {
        Zero,One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten
    }
}
