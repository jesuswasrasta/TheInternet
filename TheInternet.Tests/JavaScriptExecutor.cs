using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TheInternet.Tests.Extensions;

namespace TheInternet.Tests
{
    public class JavaScriptExecutor
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); 
        }
        
        [Test]
        public void TitleShouldBeTheInternet()
        {
            //Just a simple example on how to execute plain JavaScript on a page 
            
            driver.Url = "http://the-internet.herokuapp.com/";

            var expectedTitle = (string)driver.Scripts().ExecuteScript("return document.title");
            
            Assert.AreEqual("The Internet", expectedTitle);
        }
        
        
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}