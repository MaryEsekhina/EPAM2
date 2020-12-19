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
            homePage = new HomePage(driver);
            mainPage = homePage.ClickLink("All Products");
            productPage = mainPage.CreateProduct();
            productPage.InputValue("ProductName", "chiken legs");
            IWebElement selectElem = driver.FindElement(By.Id("CategoryId"));
            SelectElement select = new SelectElement(selectElem);
            select.SelectByValue("6");
            selectElem = driver.FindElement(By.Id("SupplierId"));
            select = new SelectElement(selectElem);
            select.SelectByValue("3");
            productPage.InputSelect("CategoryId", "6");
            productPage.InputSelect("SupplierId", "3");
            productPage.InputValue("UnitPrice", "100");
            productPage.InputValue("QuantityPerUnit", "12");
            productPage.InputValue("UnitsInStock", "200");
            productPage.InputValue("UnitsOnOrder", "12");
            productPage.InputValue("ReorderLevel", "2");
            productPage.submit();
            Assert.IsFalse(isElementPresent(By.XPath("//input[@type=\"submit\"]")));
        }

        [Test, Order(3)]
        public void Test3Check()
        {
            productPage = mainPage.OpenProduct("chiken legs");
            string productName = productPage.ReadValue("ProductName");
            string unitPrice = productPage.ReadValue("UnitPrice");
            string quantityPerUnit = productPage.ReadValue("QuantityPerUnit");
            string unitsInStock = productPage.ReadValue("UnitsInStock");
            string unitsOnOrder = productPage.ReadValue("UnitsOnOrder");
            string reorderLevel = productPage.ReadValue("ReorderLevel");
            string categoryId = productPage.ReadSelect("CategoryId");
            string supplierId = productPage.ReadSelect("SupplierId");
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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            mainPage.DeleteProduct("chiken legs");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(("//h2[text()=\"All Products\"]"))));//тк до проверки элемент не успевал исчезнуть после нажатия ОК на диалоговом окне
            Assert.IsFalse(isElementPresent(By.XPath("//table//a[text()=\"chiken legs\"]")));
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