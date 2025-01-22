using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ruapProject
{
    [TestFixture]
    public class CheckIfVATIsIncludedInPriceTest : BaseTest
    {
        [Test]
        public void CheckIfVATIsIncludedInPrice()
        {
            driver.Navigate().GoToUrl("https://www.thomann.de/intl/index.html");
            System.Threading.Thread.Sleep(10000); 
            driver.FindElement(By.XPath("//main[@id='main']/div[4]/div/div/a[10]/div[2]/span")).Click();
            driver.FindElement(By.XPath("//main[@id='main']/div[2]/div/a[3]/div[2]/span")).Click();
            driver.FindElement(By.XPath("//div[@id='17167']/div/a[2]/div/div/span[2]")).Click();
            driver.FindElement(By.XPath("//main[@id='main']/div/div/div/div/div[3]/div/div/div[3]/form/div/div/select")).Click();
            new SelectElement(driver.FindElement(By.XPath("//main[@id='main']/div/div/div/div/div[3]/div/div/div[3]/form/div/div/select"))).SelectByText("2");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.Navigate().GoToUrl("https://www.thomann.de/intl/basket.html?addedMessage=Item%20Shure%20SM%207%20B%20is%20now%20in%20the%20shopping%20basket.&addedStatus=success&gtmArticleQuantity=2&gtmArticleNumber=129929");
            driver.Navigate().GoToUrl("https://www.thomann.de/intl/basket.html");
            driver.FindElement(By.XPath("//main[@id='main']/div/div/div/div/div[2]/div/div/div/div[4]/div/div[2]/div/button")).Click();
            driver.Navigate().GoToUrl("https://www.thomann.de/intl/checkout.html");

            var headerElement = driver.FindElement(By.XPath("//*[@id=\"checkoutForm\"]/div[1]/div[2]/div[1]/div/div/div[1]/div[3]/div/div[4]/div"));
            string actualText = headerElement.Text;
            string expectedText = "The prices shown include VAT.";
            Assert.AreEqual(expectedText, actualText, "Prices shown DO NOT include VAT.");
        }
    }
}
