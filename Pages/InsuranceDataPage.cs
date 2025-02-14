using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InsuranceAppAutomation
{
    public class InsurantDataPage(IWebDriver driver) : BasePage(driver)
    {
        // Elements
        IWebElement FirstNameInput => driver.FindElement(By.Id("firstname"));
        IWebElement LastNameInput => driver.FindElement(By.Id("lastname"));
        IWebElement DateOfBirthInput => driver.FindElement(By.Id("birthdate"));
        IWebElement GenderMaleRadio => driver.FindElement(By.CssSelector("input#gendermale + span.ideal-radio"));
        IWebElement StreetAddressInput => driver.FindElement(By.Id("streetaddress"));
        IWebElement CountryDropdown => driver.FindElement(By.Id("country"));
        IWebElement ZipCodeInput => driver.FindElement(By.Id("zipcode"));
        IWebElement CityInput => driver.FindElement(By.Id("city"));
        IWebElement OccupationDropdown => driver.FindElement(By.Id("occupation"));
        IWebElement HobbiesSpeedingCheckbox => driver.FindElement(By.CssSelector("input#speeding + span.ideal-check"));
        IWebElement NextButton => driver.FindElement(By.Id("nextenterproductdata"));

        // Methods
        public void EnterFirstName(string firstName)
        {
            FirstNameInput.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            LastNameInput.SendKeys(lastName);
        }

        public void EnterDateOfBirth(string dob)
        {
            DateOfBirthInput.SendKeys(dob);
        }

        public void SelectGenderMale()
        {
            GenderMaleRadio.Click();
        }

        public void EnterStreetAddress(string address)
        {
            StreetAddressInput.SendKeys(address);
        }

        public void SelectCountry(string country)
        {
            new SelectElement(CountryDropdown).SelectByText(country);
        }

        public void EnterZipCode(string zipCode)
        {
            ZipCodeInput.SendKeys(zipCode);
        }

        public void EnterCity(string city)
        {
            CityInput.SendKeys(city);
        }

        public void SelectOccupation(string occupation)
        {
            new SelectElement(OccupationDropdown).SelectByText(occupation);
        }

        public void SelectHobbySpeeding()
        {
            HobbiesSpeedingCheckbox.Click();
        }

        public void ClickNext()
        {
            NextButton.Click();
        }
    }
}