using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheInternet.Tests.Chrome
{
    public class ChromeSettings
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            //You can setup Chrome using its capabilities before creating the WebDriver
            //http://chromedriver.chromium.org/capabilities
            
            //You can also use command line switches
            //See: https://peter.sh/experiments/chromium-command-line-switches/
            
            
            var options = new ChromeOptions();

            //Some examples:
            //- load your own Chrome setting pointing to your Chrome profile folder  
            //options.AddArguments(@"--user-data-dir=C:\Users\<MY_USERNAME>\AppData\Local\Google\Chrome\User Data");
            //- running Chrome in headless mode 
            //options.AddArgument("headless");
            //More examples: https://www.guru99.com/chrome-options-desiredcapabilities.html
            
            driver = new ChromeDriver(options);
        }
        
        [Test]
        public void ShouldPass()
        {
            Assert.Pass("Chrome configurations loaded successfully! :)");
        }
        
        
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}