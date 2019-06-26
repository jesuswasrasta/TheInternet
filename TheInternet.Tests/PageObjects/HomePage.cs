using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TheInternet.Tests.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        
        [FindsBy(How = How.LinkText, Using = "A/B Testing")]
        private IWebElement abTesting;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
        }

        public ABTestingPage GoToABTestingPage()
        {
            var link = driver.FindElement(By.LinkText("A/B Testing"));
            abTesting.Click();
//            wait.Until(ExpectedConditions.ElementToBeClickable(abTesting)).Click();
            return new ABTestingPage(driver);
        }
    }
}