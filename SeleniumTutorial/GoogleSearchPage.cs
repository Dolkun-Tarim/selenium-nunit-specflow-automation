using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationPage
{

  public  class GoogleSearchPage
    {
        IWebDriver webDriver
        { get; set; }
        public GoogleSearchPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public bool search(string searchWord)
        {
            webDriver.Navigate().GoToUrl("https://www.google.com");
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            var searchField = webDriver.FindElement(By.Name("q"));
            functionLibrary.waitForElementVisible(By.Name("q"), 30);
            functionLibrary.IsElementPresentByElementName(searchField, "Search Field");
            searchField.SendKeys(searchWord + Keys.Enter);
            var resultStatus = webDriver.FindElement(By.Id("result-stats"));
            functionLibrary.IsElementPresentByElementName(resultStatus, "Result Status");
            Console.WriteLine(resultStatus.Text);
            String searchResult = resultStatus.Text;
            String searchResultNumbers = Regex.Match(searchResult, @"\d+").Value;
            if (Int32.Parse(searchResultNumbers) > 0)
                return true;
            else
                return false;
        }


}
}
