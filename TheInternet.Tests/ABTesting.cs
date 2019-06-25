using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheInternet.Tests
{
    public class ABTesting
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
            driver.Url = "http://the-internet.herokuapp.com/";
            
            var abTestingLink = driver.FindElement(By.LinkText("A/B Testing"));
            abTestingLink.Click();
            
            
            var title = driver.FindElement(By.TagName("h3"));
            var titleExpected = "A/B Test Variation 1";

            Assert.AreEqual(titleExpected, title.Text);
            
            
            var text = driver.FindElement(By.TagName("p"));
            var textExpected = "Also known as split testing. This is a way" +
                                   " in which businesses are able to simultaneously" +
                                   " test and learn different versions of a page to see" +
                                   " which text and/or functionality works best towards a" +
                                   " desired outcome (e.g. a user action such as a click-through).";
            
            Assert.AreEqual(textExpected, text.Text);
        }
        
        
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}