using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ApplicationPage
{
   public class FunctionLibrary
    {
        public FunctionLibrary(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        IWebDriver webDriver
        { get; set; }

        public bool IsElementPresentByElementName(IWebElement webElement, string elementName)
        {
            IWebElement currentElement;
            DateTime currentTime = DateTime.Now;
            TimeSpan duration;
            for (int second = 0; ; second++)
            {
                DateTime newTime = DateTime.Now;
                currentElement = webElement;
                duration = newTime - currentTime;
                if (currentElement.Displayed)
                {
                    Console.WriteLine("{0} is found", elementName);
                    break;
                }
                if (duration.TotalSeconds >= int.Parse(ConfigurationManager.AppSettings["TimeOut"]))
                {
                    Console.WriteLine("{0} is Not found in {1} seconds", elementName, duration.TotalSeconds);
                    break;
                }
            }
            return currentElement.Displayed;
        }

        [Obsolete]
        public void waitForElementVisible(By by, int timeout)
        
            {
            Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                try
                {
                    var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
                    wait.Until(ExpectedConditions.ElementIsVisible(by));
                }
                catch (Exception)
                {
                    Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.Seconds);
                }
                finally
                {
                    stopwatch.Stop();
                }
            }

        public bool acceptAlertIfExist()
    {
        bool presentFlag = false;
        try
        {

                // Check the presence of alert
                IAlert alert = webDriver.SwitchTo().Alert();
            // Alert present; set the flag
            presentFlag = true;
            // if present consume the alert
            alert.Accept();

        }
        catch (NoAlertPresentException ex)
        {
                // Alert not present
                Console.WriteLine(ex.Message);
        }

        return presentFlag;
    }
}

    }

