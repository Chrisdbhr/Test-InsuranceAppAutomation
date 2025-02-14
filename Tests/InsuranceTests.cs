using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace InsuranceAppAutomation
{
    [TestFixture]
    public class InsuranceTests
    {
        IWebDriver driver;
        VehicleDataPage vehicleDataPage;
        InsurantDataPage insurantDataPage;

        [SetUp]
        public void Setup()
        {
            // Chrome driver setup
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sampleapp.tricentis.com/101/app.php");

            vehicleDataPage = new VehicleDataPage(driver);
            insurantDataPage = new InsurantDataPage(driver);
        }

        [Test]
        public void VehicleDataFormValidations()
        {
            // Verify Make validation
            Assert.That(vehicleDataPage.IsMakeErrorDisplayed(),
                "Make field error not shown. Expected 'Select an option'");

            vehicleDataPage.EnterEnginePerformance("");

            // Verify Engine Performance validation
            Assert.That(vehicleDataPage.IsEnginePerformanceErrorDisplayed(),
                "Engine Performance error not shown. Expected 'This field is mandatory'");

            // Fill invalid data
            vehicleDataPage.EnterEnginePerformance("Yes");

            Assert.That(vehicleDataPage.IsEnginePerformanceErrorDisplayed(),
                "Engine Performance error not shown. Expected 'Must be a number between 1 and 2000'");

            // Capture evidence
            vehicleDataPage.TakeScreenshot("validation-errors");

            // Fill valid data
            vehicleDataPage.EnterEnginePerformance("150", true);

            vehicleDataPage.TakeScreenshot("valid-data-entered");
        }

        [Test]
        public void TestInsuranceFormSubmission()
        {
            // Step 1: Enter Vehicle Data
            vehicleDataPage.SelectMake("Audi");
            vehicleDataPage.EnterEnginePerformance("150");
            vehicleDataPage.EnterDateOfManufacture("01/01/2020");
            vehicleDataPage.SelectNumberOfSeats("5");
            vehicleDataPage.SelectFuelType("Diesel");
            vehicleDataPage.EnterListPrice("50000");
            vehicleDataPage.EnterLicensePlateNumber("ABC123");
            vehicleDataPage.EnterAnnualMileage("10000");
            vehicleDataPage.TakeScreenshot("vehicle-data-filled");
            vehicleDataPage.ClickNext();

            // Step 2: Enter Insurant Data
            insurantDataPage.EnterFirstName("John");
            insurantDataPage.EnterLastName("Doe");
            insurantDataPage.EnterDateOfBirth("01/01/1990");
            insurantDataPage.SelectGenderMale();
            insurantDataPage.EnterStreetAddress("123 Main St");
            insurantDataPage.SelectCountry("United States");
            insurantDataPage.EnterZipCode("12345");
            insurantDataPage.EnterCity("New York");
            insurantDataPage.SelectOccupation("Employee");
            insurantDataPage.SelectHobbySpeeding();
            insurantDataPage.TakeScreenshot("insurant-data-filled");
            insurantDataPage.ClickNext();
        }

        [TearDown]
        public void Teardown()
        {
            // dispose resources
            driver.Quit();
            driver.Dispose();
        }
    }
}