using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheInternet.Tests
{
    public class BasicAuth
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); 
        }
        
        [Test]
        public void ShouldPass()
        {
            //See: http://elementalselenium.com/tips/13-work-with-basic-auth
            
            driver.Url = "http://admin:admin@the-internet.herokuapp.com/basic_auth/";
            var congratulation = driver.FindElement(By.TagName("p"));
            var congratulationTextExpected = "Congratulations! You must have the proper credentials.";

            Assert.AreEqual(congratulationTextExpected, congratulation.Text);
        }
        
        
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}