
using ApplicationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;

namespace SmokeTest
{
    [TestFixture]
    public class CubecartRegressionTest
    {
        IWebDriver webDriver;

        [NUnit.Framework.SetUp]
        public void Setup()
        {
            webDriver = new FirefoxDriver(Environment.CurrentDirectory);
            LoginPage loginPage = new LoginPage(webDriver);
            string url = ConfigurationManager.AppSettings["URL"];
            loginPage.openLoginPage(url);
            string username = ConfigurationManager.AppSettings["USERNAME"];
            string password = ConfigurationManager.AppSettings["PASSWORD"];
            loginPage.login(username,password);
            DashboardPage dashboardPage = new ApplicationPage.DashboardPage(webDriver);
            Assert.IsTrue(dashboardPage.verifyLogoutLink());
        }

        [Test]
        public void NavigationLinkTest()
        {
           
            DashboardPage dashboardPage = new DashboardPage(webDriver);
            Assert.IsTrue(dashboardPage.verifyNavigationLinks());
        }

        [Test]
        public void addProductTest()
        {

            DashboardPage dashboardPage = new DashboardPage(webDriver);
            dashboardPage.openProductLink();
            ProductPage productPage = new ProductPage(webDriver);
            long milliseconds = DateTime.Now.Ticks;
          Assert.IsTrue(productPage.addProduct("testautomation"+milliseconds, "New"));
        }
        [Test]
        public void addCategoryTest()
        {

            CategoryPage categoryPage = new CategoryPage(webDriver);
         Assert.IsTrue( categoryPage.addCategory("test automation" + DateTime.Now.Ticks));
          
        }
        [Test]
        public void deleteCategoryTest()
        {

            CategoryPage categoryPage = new CategoryPage(webDriver);
            Assert.IsTrue(categoryPage.deleteTopCategory());

        }

        [Test]
        public void checkCustomersTableTest()
        {

            CustomerPage customerPage = new CustomerPage(webDriver);
            Assert.IsTrue(customerPage.getTotalCustomers());

        }

        [TearDown]
        public void TearDown()
        {
            DashboardPage dashboardPage = new DashboardPage(webDriver);
            dashboardPage.logout();
            webDriver.Close();
            webDriver.Quit();
        }
    }
}