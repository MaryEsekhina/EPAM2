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
            logPage.Login("user", "user");
            string logintext = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual("Home page", logintext);
        }

        [Test, Order(2)]
        public void Test2Add()
        {
            homePage = new HomePage(driver);
            mainPage = homePage.ClickLink("All Products");
            productPage = mainPage.CreateProduct();
            productPage.InputValue("ProductName", "chiken legs");
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
            string pname = productPage.ReadValue("ProductName");
            string uprice = productPage.ReadValue("UnitPrice");
            string qpu = productPage.ReadValue("QuantityPerUnit");
            string uis = productPage.ReadValue("UnitsInStock");
            string uoo = productPage.ReadValue("UnitsOnOrder");
            string rlevel = productPage.ReadValue("ReorderLevel");
            string category = productPage.ReadSelect("CategoryId");
            string supplier = productPage.ReadSelect("SupplierId");
            Assert.AreEqual(category, "Meat/Poultry");
            Assert.AreEqual(supplier, "Grandma Kelly's Homestead");
            Assert.AreEqual(pname, "chiken legs");
            Assert.AreEqual(uprice, "100,0000");
            Assert.AreEqual(qpu, "12");
            Assert.AreEqual(uis, "200");
            Assert.AreEqual(uoo, "12");
            Assert.AreEqual(rlevel, "2");
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
            mainPage.Logout();
            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "Login");
        }


        [OneTimeTearDown]
        public void QuitDriver()
        {
            driver.Close();
            driver.Quit();
        }

    }
}