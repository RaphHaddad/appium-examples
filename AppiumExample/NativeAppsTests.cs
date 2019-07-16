using AppiumExample.Apps;
using Xunit;

namespace AppiumExample
{
    public class NativeAppsTests
    {
        [Fact]
        public void NotepadTests()
        {
            var notepad = new Notepad();
            notepad.EditText("This is some text");
            notepad.Close();
        }

        [Fact]
        public void CalculatorTests()
        {
            var calculator = new Calculator();
            calculator.ClickNumber(Numbers.Two);
            calculator.ClickMultiply();
            calculator.ClickNumber(Numbers.Three);
            calculator.ClickEquals();
            var result = calculator.Result();

            Assert.Equal(6.0, result);
            calculator.Close();
        }
    }
}
