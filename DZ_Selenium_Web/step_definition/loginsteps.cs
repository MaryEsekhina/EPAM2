using DZ_Selenium_Web.pageobj;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DZ_Selenium_Web.step_definition
{
    [Binding]
    class loginsteps
    {
        private IWebDriver driver;
        private LoginPage LogPage;
        private ProductPage productPage;
        private MainPage mainPage;

        [Given(@"I open ""(.+)"" url")]
        public void GivenIOpenLoginPage(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }
        [When(@"I enter the login ""(.+)""")]
        public void WhenIEnterTheLogin(string login)
        {
            LogPage = new LoginPage(driver);
            LogPage.InputLogin(login);
        }

        [When(@"I enter the password ""(.+)""")]
        public void WhenIEnterThePassword(string password)
        {
            LogPage.InputPassword(password);
        }

        [When(@"I click on submit button")]
        public void WhenIClickTheSubmitButton()
        {
            LogPage.ClickSubmit();
        }

        [When(@"I click on ""(.+)""")]
        public void WhenIClickOn(string link)
        {
            new HomePage(driver).ClickLink(link);
        }

        [When(@"I click on Create button")]
        public void WhenIClickOnCreateButton()
        {
            mainPage = new MainPage(driver);
            mainPage.ClickCreate();
        }

        [When(@"I input ""(.+)"" in ProductName")]
        public void WhenIInputInProductName(string productname)
        {
            productPage = new ProductPage(driver);
            productPage.InputProductName(productname);
        }

        [When(@"I input ""(.+)"" in Category")]
        public void WhenIInputInCategory(string Category)
        {
            productPage.InputCategoryId(Category);
        }

        [When(@"I input """"(.+)"" in Supplier")]
        public void WhenIInputInSupplier(string Supplier)
        {
            productPage.InputSupplierId(Supplier);
        }

        [When(@"I input ""(.+)"" in Unitprice")]
        public void WhenIInputInUnitprice(string Unitprice)
        {
            productPage.InputUnitPrice(Unitprice);
        }

        [When(@"I click on send button")]
        public void WhenIClickOnSendButton()
        {
            productPage.submit();
        }

        [Then(@"there is ""(.+)"" in the list")]
        public void ThenThereIsInTheList(string product)
        {
            Assert.IsTrue(mainPage.IsProductPresent(product));
        }


        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
