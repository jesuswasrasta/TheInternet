using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheInternet.Tests
{
    public class Links
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); 
        }
        
        [Test]
        public void ShouldNotFindLinkWithSpaces()
        {
            driver.Url = "http://the-internet.herokuapp.com/";
            Assert.Throws<NoSuchElementException>(() => { driver.FindElement(By.LinkText("A/B     Testing")); });
        }   
        
        [Test]
        public void ShouldNotFindLinkWithDifferentCase()
        {
            driver.Url = "http://the-internet.herokuapp.com/";
            Assert.Throws<NoSuchElementException>(() => { driver.FindElement(By.LinkText("a/b testing")); });
        }

        [Test]
        public void ShouldPass()
        {
            driver.Url = "http://the-internet.herokuapp.com/";
            var abTestingLink = driver.FindElement(By.LinkText("A/B Testing"));
            Assert.NotNull(abTestingLink);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}