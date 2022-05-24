using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace ApplicationPage
{
   public class CategoryPage
    {
    private    IWebDriver webDriver
        { get; set; }
    private WebDriverWait wait;
        public CategoryPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.Id, Using = "nav_categories")]
        [CacheLookup]
        private IWebElement categoriesLink;

        [FindsBy(How = How.LinkText, Using = "Add Category")]
        [CacheLookup]
        private IWebElement addCategoryLink;

        [FindsBy(How = How.XPath, Using = "//img[@rel='#status']")]
        [CacheLookup]
        private IWebElement categoryStatus;

        [FindsBy(How = How.XPath, Using = "//img[@rel='#visible']")]
        [CacheLookup]
        private IWebElement categoryVisibility;

        [FindsBy(How = How.Name, Using = "cat[cat_name]")]
        [CacheLookup]
        private IWebElement categoryName;

        [FindsBy(How = How.Id, Using = "cat_save")]
        [CacheLookup]
        private IWebElement saveButton;

        [FindsBy(How = How.CssSelector, Using = "div.success")]
        [CacheLookup]
        private IWebElement confirmationMessage;

        [FindsBy(How = How.XPath, Using = "//div[@id='categories']/table/tbody/tr/td/a/i[@class='fa fa-trash']")]
        [CacheLookup]
        private IWebElement deleteIcon;



        public bool addCategory(string catName)
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            functionLibrary.IsElementPresentByElementName(categoriesLink, "Category Link");
            categoriesLink.Click();
            functionLibrary.IsElementPresentByElementName(addCategoryLink, "Add Category Link");
            addCategoryLink.Click();
            functionLibrary.IsElementPresentByElementName(categoryStatus, "Category Status");
            categoryStatus.Click();
            functionLibrary.IsElementPresentByElementName(categoryVisibility, "Category Visibility");
            categoryVisibility.Click();
            functionLibrary.IsElementPresentByElementName(categoryName, "Category Name");
            categoryName.SendKeys(catName);
            functionLibrary.IsElementPresentByElementName(saveButton, "Save Button");
            saveButton.Click();
            functionLibrary.IsElementPresentByElementName(confirmationMessage, "Confirmation Message ");
            if (confirmationMessage.Displayed)
                return true;
            else
                return false;
        }

        public bool deleteTopCategory()
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            functionLibrary.IsElementPresentByElementName(categoriesLink, "Category Link");
            categoriesLink.Click();
            functionLibrary.IsElementPresentByElementName(deleteIcon, "Delete icon");
            deleteIcon.Click();
            functionLibrary.acceptAlertIfExist();
            functionLibrary.IsElementPresentByElementName(confirmationMessage, "Confirmation Message");
            string confirmationMessageText = confirmationMessage.Text;
            if (confirmationMessageText.Contains("deleted"))
                return true;
            else
                return false;

        }

        

    }
}
