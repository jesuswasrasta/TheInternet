using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;

namespace TheInternet.Tests
{
    public class CheckBoxes
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); 
        }
        
        [Test]
        public void FirstUncheckedSecondChecked()
        {   
            driver.Url = "http://the-internet.herokuapp.com/checkboxes";

            var checkBoxes = driver.FindElements(By.CssSelector("input[type=checkbox"));

            Assert.IsNotNull(checkBoxes);
            Assert.AreEqual(2, checkBoxes.Count);
            Assert.IsFalse(checkBoxes[0].Selected);

            var isLastChecked = checkBoxes.Last().Selected;
            Assert.IsTrue(isLastChecked);
        }
        
        [Test]
        public void CheckFirstUncheckedSecond()
        {   
            driver.Url = "http://the-internet.herokuapp.com/checkboxes";

            var checkBoxes = driver.FindElements(By.CssSelector("input[type=checkbox"));

            var first = checkBoxes[0];
            Assert.IsFalse(first.Selected);
            first.Click();
            Assert.IsTrue(first.Selected);

            var second = checkBoxes[1];
            Assert.IsTrue(second.Selected);
            second.Click();
            Assert.IsFalse(second.Selected);
        }
        
        
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}