using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace ApplicationPage
{
   public class DashboardPage
    {
        IWebDriver webDriver
        { get; set; }
        int timeout = 30;
        public DashboardPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public bool verifyLogoutLink()
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            By logoutButtonByCss = By.CssSelector("i.fa.fa-sign-out");
            IWebElement logoutLink = webDriver.FindElement(logoutButtonByCss);
            functionLibrary.waitForElementVisible(logoutButtonByCss, timeout);
            if (logoutLink.Displayed)
                return true;
            else
                return false;
        }

        public bool verifyProductLink()
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            By productNavigationLinkById = By.Id("nav_products");
            IWebElement productLink = webDriver.FindElement(productNavigationLinkById);
            functionLibrary.waitForElementVisible(productNavigationLinkById, timeout);
            if (productLink.Displayed)
                return true;
            else
                return false;
        }

        public void logout()
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            By logoutButtonByCss = By.CssSelector("i.fa.fa-sign-out");
            IWebElement logoutLink = webDriver.FindElement(logoutButtonByCss);
            functionLibrary.waitForElementVisible(logoutButtonByCss, timeout);
            logoutLink.Click();
        }

        public bool verifyNavigationLinks()
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            IList<IWebElement> allLinks = webDriver.FindElements(By.XPath("//div[@id='navigation']//a"));
            int totalLinks = allLinks.Count;
            if (totalLinks >= 1)
            {
                foreach (IWebElement eachLink in allLinks)
                {
                    string hyperLink = eachLink.GetAttribute("href");
                    Console.WriteLine(hyperLink);
                }
                return true;

            }
            else
                return false;
        }

        public void openProductLink()
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            By productLinkById = By.Id("nav_products");
            IWebElement productLink = webDriver.FindElement(productLinkById);
            functionLibrary.waitForElementVisible(productLinkById, timeout);
            productLink.Click();
        }

    }
}
