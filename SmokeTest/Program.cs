using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using ApplicationPage;

namespace SmokeTest
{
    class Program
    {
        private static void Main(string[] args)
        {
            IWebDriver webDriver = new FirefoxDriver(Environment.CurrentDirectory);
            GoogleSearchPage googleSearchPage = new ApplicationPage.GoogleSearchPage(webDriver);
            bool searchResult = googleSearchPage.search("Java");
            Console.WriteLine("Search Result is " + searchResult);
            webDriver.Close();
            webDriver.Quit();
        }
    }
}
