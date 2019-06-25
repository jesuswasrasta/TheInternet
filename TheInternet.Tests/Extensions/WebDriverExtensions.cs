using OpenQA.Selenium;

namespace TheInternet.Tests.Extensions
{
    public static class WebDriverExtensions
    {
        public static IJavaScriptExecutor Scripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor) driver;
        }
    }
}