using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;


namespace ApplicationPage
{
   public class CustomerPage
    {
    private    IWebDriver webDriver
        { get; set; }
    private WebDriverWait wait;
        public CustomerPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Customer List")]
        [CacheLookup]
        private IWebElement customerListLink;

        [FindsBy(How = How.XPath, Using = "//div[@id='customer-list']/table")]
        [CacheLookup]
        private IWebElement customerTable;

        [FindsBy(How = How.XPath, Using = "//div[@id='customer-list']/table/tbody/tr")]
        [CacheLookup]
        private IList<IWebElement> customerRecords;





        public bool getTotalCustomers()
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            functionLibrary.IsElementPresentByElementName(customerListLink, "Customer List Link");
            customerListLink.Click();
            functionLibrary.IsElementPresentByElementName(customerTable, "Customer Table");
            int totalCustomers = customerRecords.Count;
            Console.WriteLine("Total customers: {0}", totalCustomers);
            if (totalCustomers>=1)
                return true;
            else
                return false;
        }

    }
}
