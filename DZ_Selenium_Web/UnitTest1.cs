using DZ_Selenium_Web.business_object;
using DZ_Selenium_Web.pageobj;
using DZ_Selenium_Web.service;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace DZ_Selenium_Web
{
    public class Tests
    {

        private IWebDriver driver;
        private LoginPage logPage;
        private HomePage homePage;
        private MainPage mainPage;
        private Product chikenLegs = new Product("chiken legs", "Meat/Poultry", "Grandma Kelly's Homestead", 100, "12", "200", "12", "2");
        private ProductService productService;

        public bool isElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
        }

        [Test, Order(1)]
        public void Test1Login()
        {
            logPage = new LoginPage(driver);
            homePage = logPage.Login("user", "user");
            string logintext = homePage.TitleText();
            Assert.AreEqual("Home page", logintext);
        }

        [Test, Order(2)]
        public void Test2Add()
        {
            productService = new ProductService();
            productService.InputProduct(chikenLegs, driver);
            Assert.IsFalse(isElementPresent(By.XPath("//input[@type=\"submit\"]")));
        }

        [Test, Order(3)]
        public void Test3Check()
        {
            Product productCheck = productService.ReadProduct(chikenLegs, driver);
            Assert.AreEqual(productCheck.categoryId, chikenLegs.categoryId);
            Assert.AreEqual(productCheck.supplierId, chikenLegs.supplierId);
            Assert.AreEqual(productCheck.productName, chikenLegs.productName);
            Assert.AreEqual(productCheck.unitPrice, chikenLegs.unitPrice);
            Assert.AreEqual(productCheck.quantityPerUnit, chikenLegs.quantityPerUnit);
            Assert.AreEqual(productCheck.unitsInStock, chikenLegs.unitsInStock);
            Assert.AreEqual(productCheck.unitsOnOrder, chikenLegs.unitsOnOrder);
            Assert.AreEqual(productCheck.reorderLevel, chikenLegs.reorderLevel);

        }

        [Test, Order(4)]
        public void Test4Delete()
        {
            productService.DeleteProduct(chikenLegs, driver);
            Assert.IsFalse(isElementPresent(By.XPath("//table//a[text()=\"chiken legs\"]")));
        }

        [Test, Order(5)]
        public void Test5Logout()
        {
            mainPage = new MainPage(driver);
            logPage = mainPage.Logout();
            string logintext = logPage.TitleText();
            Assert.AreEqual(logintext, "Login");
        }


        [OneTimeTearDown]
        public void QuitDriver()
        {
            driver.Close();
            driver.Quit();
        }

    }
}