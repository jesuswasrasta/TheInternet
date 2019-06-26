using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TheInternet.Tests.PageObjects
{
    public class ABTestingPage
    {
        [FindsBy(How = How.TagName, Using = "h3")]
        private IWebElement title;

        [FindsBy(How = How.TagName, Using = "p")]
        private IWebElement text;

        public ABTestingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string GetTitle()
        {
            return title.Text;
        }
        
        public string GetText()
        {
            return text.Text;
        }
    }
}