using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ruapProject;

[TestFixture]
public class VerifyImportantLinksArePresentTest : BaseTest
{
    [Test]
    public void VerifyImportantLinksArePresent()
    {
        driver.Navigate().GoToUrl("https://www.ebay.com/");
        
        Assert.IsTrue(IsElementPresent(By.CssSelector(".gh-ship-to__menu-text")), "'Ship to' link is not present on the page.");
        Assert.IsTrue(IsElementPresent(By.CssSelector(".gh-nav-link > a[href='https://www.ebay.com/sl/sell']")), "'Sell' link is not present on the page.");
        Assert.IsTrue(IsElementPresent(By.CssSelector(".gh-flyout__target[href='https://www.ebay.com/mye/myebay/watchlist']")), "'Watchlist' link is not present on the page.");
        Assert.IsTrue(IsElementPresent(By.CssSelector(".gh-flyout__target[href='https://www.ebay.com/mys/home?source=GBH']")), "'My eBay' link is not present on the page.");
    }
}