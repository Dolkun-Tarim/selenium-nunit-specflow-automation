
using ApplicationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text.RegularExpressions;

namespace SmokeTest
{
    [TestFixture]
    public class RegressionTest
    {
        IWebDriver webDriver;

        [NUnit.Framework.SetUp]
        public void Setup()
        {
            webDriver = new FirefoxDriver(Environment.CurrentDirectory);
           
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
            webDriver.Close();
            webDriver.Quit();
        }
    }
}