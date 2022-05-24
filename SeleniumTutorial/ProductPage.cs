using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ApplicationPage
{
   public class ProductPage
    {
        IWebDriver webDriver
        { get; set; }
        int timeout = 30;
        public ProductPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        
        public bool addProduct(string productName,string productCondition)
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            By addProductLinkByLinkText = By.LinkText("Add Product");
            IWebElement addProductLink = webDriver.FindElement(addProductLinkByLinkText);
            functionLibrary.waitForElementVisible(addProductLinkByLinkText, timeout);
            addProductLink.Click();

            By productNameFieldById = By.Id("name");
            IWebElement productNameField = webDriver.FindElement(productNameFieldById);
            functionLibrary.waitForElementVisible(productNameFieldById, timeout);
            productNameField.SendKeys(productName);

            By productConditionSelectById = By.Id("condition");
            IWebElement productConditionSelect = webDriver.FindElement(productConditionSelectById);
            functionLibrary.waitForElementVisible(productConditionSelectById, timeout);
            SelectElement productConditionDropdown = new SelectElement(productConditionSelect);
            productConditionDropdown.SelectByText(productCondition);

            By saveButtonById = By.XPath("//input[@value='Save']");
            IWebElement saveButton = webDriver.FindElement(saveButtonById);
            functionLibrary.waitForElementVisible(saveButtonById, timeout);
            saveButton.Click();

            By confirmationMessageByCss = By.CssSelector("div.success");
            IWebElement confirmationMessage = webDriver.FindElement(confirmationMessageByCss);
            functionLibrary.waitForElementVisible(confirmationMessageByCss, timeout);
            if (confirmationMessage.Displayed)
                return true;
            else
                return false;


        }

        

        

    }
}
