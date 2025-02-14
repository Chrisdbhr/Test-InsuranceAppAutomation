using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InsuranceAppAutomation
{
    public class VehicleDataPage(IWebDriver driver) : BasePage(driver)
    {
        // Elements
        IWebElement MakeDropdown => Driver.FindElement(By.Id("make"));
        IWebElement EnginePerformanceInput => Driver.FindElement(By.Id("engineperformance"));
        IWebElement DateOfManufactureInput => Driver.FindElement(By.Id("dateofmanufacture"));
        IWebElement NumberOfSeatsDropdown => Driver.FindElement(By.Id("numberofseats"));
        IWebElement FuelTypeDropdown => Driver.FindElement(By.Id("fuel"));
        IWebElement ListPriceInput => Driver.FindElement(By.Id("listprice"));
        IWebElement LicensePlateNumberInput => Driver.FindElement(By.Id("licenseplatenumber"));
        IWebElement AnnualMileageInput => Driver.FindElement(By.Id("annualmileage"));
        IWebElement NextButton => Driver.FindElement(By.Id("nextenterinsurantdata"));

        // Validation error locators
        By MakeErrorLocator => By.CssSelector("div.idealforms-field-select-one.invalid span.error");
        By EnginePerfErrorLocator => By.XPath("//input[@id='engineperformance']/following-sibling::span[contains(@class,'error')]");

        // Methods
        public void SelectMake(string make)
        {
            new SelectElement(MakeDropdown).SelectByText(make);
        }

        public void EnterEnginePerformance(string performance, bool clear = false)
        {
            if(clear) EnginePerformanceInput.Clear();
            EnginePerformanceInput.SendKeys(performance);
        }

        public void EnterDateOfManufacture(string date)
        {
            DateOfManufactureInput.SendKeys(date);
        }

        public void SelectNumberOfSeats(string seats)
        {
            new SelectElement(NumberOfSeatsDropdown).SelectByText(seats);
        }

        public void SelectFuelType(string fuelType)
        {
            new SelectElement(FuelTypeDropdown).SelectByText(fuelType);
        }

        public void EnterListPrice(string price)
        {
            ListPriceInput.SendKeys(price);
        }

        public void EnterLicensePlateNumber(string plateNumber)
        {
            LicensePlateNumberInput.SendKeys(plateNumber);
        }

        public void EnterAnnualMileage(string mileage)
        {
            AnnualMileageInput.SendKeys(mileage);
        }

        public void ClickNext()
        {
            NextButton.Click();
        }

        // Validation methods with explicit waits
        public bool IsMakeErrorDisplayed()
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(1))
                    .Until(d => d.FindElement(MakeErrorLocator).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsEnginePerformanceErrorDisplayed()
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(1))
                    .Until(d => d.FindElement(EnginePerfErrorLocator).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}