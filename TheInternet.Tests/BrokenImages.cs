using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;

namespace TheInternet.Tests
{
    public class BrokenImages
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); 
        }
        
        [TestCase("asdf.jpg", HttpStatusCode.NotFound)]
        [TestCase("hjkl.jpg", HttpStatusCode.NotFound)]
        [TestCase("img/avatar-blank.jpg", HttpStatusCode.OK)]
        public void ShouldPass(string imageUrl, HttpStatusCode expectedHttpStatusCode)
        {   
            driver.Url = "http://the-internet.herokuapp.com/";

            var brokenImagesLink = driver.FindElement(By.LinkText("Broken Images"));
            brokenImagesLink.Click();
            
            var divContainers = driver.FindElements(By.ClassName("example"));
            var divElement = divContainers.First();

            var images = divElement.FindElements(By.TagName("img")).ToList();
            var imageSource = images.First(x => x.GetAttribute("src").Contains(imageUrl));
            
            var restRequest = new RestRequest();
            var restClient = new RestClient(imageSource.GetAttribute("src"));
            var response = restClient.Execute(restRequest);
            var actualStatusCode = response.StatusCode;

            Assert.AreEqual(expectedHttpStatusCode, actualStatusCode);
        }
        
        
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}