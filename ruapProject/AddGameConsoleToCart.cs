using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ruapProject
{
    [TestFixture]
    public class AddGameConsoleToCartTest : BaseTest
    {
        [Test]
        public void TheEbayTest()
        {
            driver.Navigate().GoToUrl("https://www.ebay.com/");
            driver.FindElement(By.XPath("//header[@id='gh']/section/div/div/div/button")).Click();
            driver.FindElement(By.LinkText("Video Games & Consoles")).Click();
            driver.FindElement(By.XPath("//img[@alt='Sony PlayStation PSP 1000/2000/3000 Console with Charger/New Battery Region Free']")).Click();
            driver.FindElement(By.XPath("//a[@id='atcBtn_btn_1']/span/span")).Click();
            driver.Navigate().GoToUrl("https://cart.payments.ebay.com/sc/add?srt=01000a000000503f5f603ed754756e305f4b775c7f9d38549971eacc79d66c7961a078d9cc5ee46564a668f526365e3dfaa76c81918b35121f97070a7c176328b85e48f43c040ffc28051b427000c80b53919aeddb367f&item=iid:204309390922,qty:1,vid:504861192400&ssPageName=CART:ATC");
            driver.Navigate().GoToUrl("https://cart.payments.ebay.com/?item=iid%3A204309390922%2Cqty%3A1%2Cvid%3A504861192400");
        }
    }
}