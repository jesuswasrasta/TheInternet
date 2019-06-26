using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheInternet.Tests.PageObjects
{
    public class ABTestingPageTest
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchTextFromAboutPage()
        {
            const string titleExpected = "A/B Test Variation 1";
            const string textExpected = "Also known as split testing. This is a way" +
                                        " in which businesses are able to simultaneously" +
                                        " test and learn different versions of a page to see" +
                                        " which text and/or functionality works best towards a" +
                                        " desired outcome (e.g. a user action such as a click-through).";

            var homePage = new HomePage(driver);
            homePage.Navigate();
            var abTestingPage = homePage.GoToABTestingPage();
            var title = abTestingPage.GetTitle();
            var text = abTestingPage.GetText();

            Assert.AreEqual(titleExpected, title);
            Assert.AreEqual(textExpected, text);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}