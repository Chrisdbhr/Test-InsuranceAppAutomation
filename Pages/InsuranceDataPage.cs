using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InsuranceAppAutomation
{
    public class InsurantDataPage(IWebDriver driver) : BasePage(driver)
    {
        // Elements
        IWebElement FirstNameInput => Driver.FindElement(By.Id("firstname"));
        IWebElement LastNameInput => Driver.FindElement(By.Id("lastname"));
        IWebElement DateOfBirthInput => Driver.FindElement(By.Id("birthdate"));
        IWebElement GenderMaleRadio => Driver.FindElement(By.CssSelector("input#gendermale + span.ideal-radio"));
        IWebElement StreetAddressInput => Driver.FindElement(By.Id("streetaddress"));
        IWebElement CountryDropdown => Driver.FindElement(By.Id("country"));
        IWebElement ZipCodeInput => Driver.FindElement(By.Id("zipcode"));
        IWebElement CityInput => Driver.FindElement(By.Id("city"));
        IWebElement OccupationDropdown => Driver.FindElement(By.Id("occupation"));
        IWebElement HobbiesSpeedingCheckbox => Driver.FindElement(By.CssSelector("input#speeding + span.ideal-check"));
        IWebElement NextButton => Driver.FindElement(By.Id("nextenterproductdata"));

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