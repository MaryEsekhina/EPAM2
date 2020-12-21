using DZ_Selenium_Web.pageobj;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace DZ_Selenium_Web
{
    public class Tests
    {

        private IWebDriver driver;
        private LoginPage logPage;
        private HomePage homePage;
        private ProductPage productPage;
        private MainPage mainPage;
        private WebDriverWait wait;


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
            homePage = new HomePage(driver);
            mainPage = homePage.ClickLink("All Products");
            productPage = mainPage.CreateProduct();
            productPage.InputProductName("chiken legs");
            productPage.InputCategoryId("Meat/Poultry");
            productPage.InputSupplierId("Grandma Kelly's Homestead");
            productPage.InputUnitPrice("100");
            productPage.InputQuantityPerUnit("12");
            productPage.InputUnitsInStock("200");
            productPage.InputUnitsOnOrder("12");
            productPage.InputReorderLevel("2");
            productPage.submit();
            Assert.IsFalse(productPage.IsSubmitPresent(driver));
        }

        [Test, Order(3)]
        public void Test3Check()
        {
            productPage = mainPage.OpenProduct("chiken legs");
            string productName = productPage.ReadProductName();
            string unitPrice = productPage.ReadUnitPrice();
            string quantityPerUnit = productPage.ReadQuantityPerUnit();
            string unitsInStock = productPage.ReadUnitsInStock();
            string unitsOnOrder = productPage.ReadUnitsOnOrder();
            string reorderLevel = productPage.ReadReorderLevel();
            string categoryId = productPage.ReadCategoryId();
            string supplierId = productPage.ReadSupplierId();
            Assert.AreEqual(categoryId, "Meat/Poultry");
            Assert.AreEqual(supplierId, "Grandma Kelly's Homestead");
            Assert.AreEqual(productName, "chiken legs");
            Assert.AreEqual(unitPrice, "100,0000");
            Assert.AreEqual(quantityPerUnit, "12");
            Assert.AreEqual(unitsInStock, "200");
            Assert.AreEqual(unitsOnOrder, "12");
            Assert.AreEqual(reorderLevel, "2");
            productPage.ClickProducts();
        }

        [Test, Order(4)]
        public void Test4Delete()
        {
            mainPage.DeleteProduct("chiken legs");
            mainPage.WaitAllProducts(driver);
            Assert.IsFalse(mainPage.IsProductPresent("chiken legs", driver));
        }

        [Test, Order(5)]
        public void Test5Logout()
        {
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