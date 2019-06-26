using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TheInternet.Tests
{
    public class Timeouts
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
            // Decide decide how long you want to wait
            TimeSpan ts = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, ts); 
            // Define an expected condition to wait for. // Here it is an alert pop up to appear.
            var alert = wait.Until(ExpectedConditions.AlertIsPresent());

            
            Assert.Pass("Setup complete :)");
        }
    }
}