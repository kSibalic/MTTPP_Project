using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ruapProject
{
    [TestFixture]
    public class ChangeUsersAddressTest : BaseTest
    {
        [Test]
        public void TheChangeUsersAddress()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://www.thomann.de/intl/index.html");
            var headerElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='main']/div[1]/h1")));
            string actualHeaderText = headerElement.Text;
            
            bool isLoggedIn = actualHeaderText.Contains("Welcome to Thomann, Ruap!");
            if (!isLoggedIn)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div/div[3]/div/div[1]"))).Click();
                var usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("uname")));
                usernameField.Clear();
                usernameField.SendKeys("ruaptesting@gmail.com");
                var passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("passw")));
                passwordField.Clear();
                passwordField.SendKeys("Ruap123!");
                
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@type='submit']"))).Click();
                headerElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='main']/div[1]/h1")));
                actualHeaderText = headerElement.Text;
                
                int retries = 0;
                while (!actualHeaderText.Contains("Welcome to Thomann, Ruap!") && retries < 5)
                {
                    Thread.Sleep(1000);
                    headerElement = driver.FindElement(By.XPath("//*[@id='main']/div[1]/h1"));
                    actualHeaderText = headerElement.Text;
                    retries++;
                }
                string expectedText = "Welcome to Thomann, Ruap!";
                Assert.AreEqual(expectedText, actualHeaderText, $"The header text after login is incorrect! Expected: '{expectedText}', but was: '{actualHeaderText}'");
            }
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div/div[3]/div/div[1]"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Edit Your Account"))).Click();
            driver.Navigate().GoToUrl("https://www.thomann.de/intl/mythomann_account.html");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Address book"))).Click();
            driver.Navigate().GoToUrl("https://www.thomann.de/intl/mythomann_addressbook.html");
            var editButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("svg.fx-icon.fx-icon--edit")));
            editButton.Click();
            var streetField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("street")));
            streetField.Clear();
            streetField.SendKeys("Ulica kneza Trpimira 2a");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='mythomann-address-book']/div[2]/div/div[8]/button"))).Click();
        }
    }
}
