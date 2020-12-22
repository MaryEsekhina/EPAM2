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
        private ProductPage productPage;
        private Product chikenLegs = new Product("chiken legs", "Meat/Poultry", "Grandma Kelly's Homestead", 100, "12", "200", "12", "2");
        private ProductService productService;



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
            productPage = new ProductPage(driver);
            productService.InputProduct(chikenLegs, driver);
            Assert.IsFalse(productPage.IsSubmitPresent());
        }

        [Test, Order(3)]
        public void Test3Check()
        {
            Product productCheck = productService.ReadProduct(chikenLegs, driver);
            Assert.AreEqual( chikenLegs.categoryId, productCheck.categoryId);
            Assert.AreEqual(chikenLegs.supplierId, productCheck.supplierId);
            Assert.AreEqual(chikenLegs.productName, productCheck.productName);
            Assert.AreEqual(chikenLegs.unitPrice, productCheck.unitPrice);
            Assert.AreEqual(chikenLegs.quantityPerUnit, productCheck.quantityPerUnit);
            Assert.AreEqual(chikenLegs.unitsInStock, productCheck.unitsInStock);
            Assert.AreEqual(chikenLegs.unitsOnOrder, productCheck.unitsOnOrder);
            Assert.AreEqual(chikenLegs.reorderLevel, productCheck.reorderLevel);

        }

        [Test, Order(4)]
        public void Test4Delete()
        {
            mainPage = new MainPage(driver);
            productService.DeleteProduct(chikenLegs, driver);
            Assert.IsFalse(mainPage.IsProductPresent(chikenLegs, driver));
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