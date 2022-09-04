
using ApplicationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using WebDriverManager.Helpers;

namespace SmokeTest
{
    [TestFixture]
    public class RegressionTest
    {
        IWebDriver webDriver;

        [NUnit.Framework.SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();
           
        }

        [Test]
        public void GoogleSearchTest1()
        {
            GoogleSearchPage googleSearchPage = new ApplicationPage.GoogleSearchPage(webDriver);
          bool searchResult=  googleSearchPage.search("Java");
            Assert.IsTrue(searchResult);
        }
        [Test]
        public void GoogleSearchTest2()
        {
            GoogleSearchPage googleSearchPage = new ApplicationPage.GoogleSearchPage(webDriver);
            bool searchResult = googleSearchPage.search("Python");
            Assert.IsTrue(searchResult);
        }
        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }
    }
}