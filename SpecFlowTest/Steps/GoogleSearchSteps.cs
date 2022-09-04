using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using FluentAssertions;
using ApplicationPage;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class GoogleSearchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        String searchWord = "Java";
        bool searchResult;
        IWebDriver webDriver;
        public GoogleSearchSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"a keyword string to search")]
        public void GivenAKeywordStringToSearch()
        {
            Console.WriteLine(searchWord);
        }
        
        [When(@"the a user search the string on google")]
        public void WhenTheAUserSearchTheStringOnGoogle()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(webDriver);
            searchResult = googleSearchPage.search(searchWord);
        }
        
        [Then(@"google should return search result")]
        public void ThenGoogleShouldReturnSearchResult()
        {
            webDriver.Quit();
            searchResult.Should().BeTrue();

        }
    }
}
