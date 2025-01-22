using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MTTPP_Project
{
    [TestFixture]
    public class YouTubeLinkTest : BaseTest
    {
        [Test]
        public void VerifyYouTubeLinkOpensInNewTab()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://www.thomann.de/intl/index.html");
            
            try
            {
                var rejectCookiesButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("reject-cookies-button")));
                rejectCookiesButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                // Proceed if no cookie banner is shown
            }
            
            var linkElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/footer/div[5]/div/div/div[2]/div/div[1]/a[2]")));
            string expectedUrl = linkElement.GetAttribute("href");
            Assert.IsNotNull(expectedUrl, "The link does not have an href attribute.");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open(arguments[0]);", expectedUrl);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            
            try
            {
                var rejectCookiesButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("reject-cookies-button")));
                rejectCookiesButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                // Proceed if no cookie banner is shown
            }
            
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, "The opened URL does not match the expected YouTube URL.");
            
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }
    }
}
