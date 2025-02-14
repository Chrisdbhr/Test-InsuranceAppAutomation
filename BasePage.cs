using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InsuranceAppAutomation
{
    public class BasePage(IWebDriver driver)
    {
        protected readonly IWebDriver Driver = driver;
        IWebElement AutomobileButton => Driver.FindElement(By.Id("nav_automobile"));
        By AutomobileInsuranceLabelLocator => By.Id("selectedinsurance");

        public void TakeScreenshot(string fileName)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile($"screenshots/{fileName}.png");
        }

        public void SelectAutomobileTypeOfInsurance()
        {
            AutomobileButton.Click();
            new WebDriverWait(Driver, TimeSpan.FromSeconds(3))
                .Until(d => d.FindElement(AutomobileInsuranceLabelLocator).Text == "Automobile Insurance");
        }

    }
}