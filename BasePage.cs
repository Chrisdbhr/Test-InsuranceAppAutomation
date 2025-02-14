// BasePage.cs
using OpenQA.Selenium;

namespace InsuranceAppAutomation
{
    public class BasePage(IWebDriver driver)
    {
        protected readonly IWebDriver driver = driver;

        public void TakeScreenshot(string fileName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile($"screenshots/{fileName}.png");
        }

    }
}