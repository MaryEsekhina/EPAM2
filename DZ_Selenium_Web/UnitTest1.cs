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
            
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            string logintext = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual("Home page", logintext);
        }

        [Test, Order(2)]
        public void Test2Add()
        {
            driver.FindElement(By.XPath("//div/div/a[text()=\"All Products\"]")).Click();
            driver.FindElement(By.XPath("//div/a[text()=\"Create new\"]")).Click();
            driver.FindElement(By.Id("ProductName")).SendKeys("chiken legs");
            IWebElement selectElemCat = driver.FindElement(By.Id("CategoryId"));
            SelectElement selectCat = new SelectElement(selectElemCat);
            selectCat.SelectByValue("6");
            IWebElement selectElemSup = driver.FindElement(By.Id("SupplierId"));
            SelectElement selectSup = new SelectElement(selectElemSup);
            selectSup.SelectByValue("3");
            driver.FindElement(By.Id("UnitPrice")).SendKeys("100");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("12");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("200");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("12");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("2");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Assert.IsFalse(isElementPresent(By.XPath("//input[@type=\"submit\"]")));
        }

        [Test, Order(3)]
        public void Test3Check()
        {
            driver.FindElement(By.XPath("//a[text()=\"chiken legs\"]")).Click();
            string pname = driver.FindElement(By.XPath("//input[@name=\"ProductName\"]")).GetAttribute("value");
            string uprice = driver.FindElement(By.XPath("//input[@id=\"UnitPrice\"]")).GetAttribute("value");
            string qpu = driver.FindElement(By.XPath("//input[@id=\"QuantityPerUnit\"]")).GetAttribute("value");
            string uis = driver.FindElement(By.XPath("//input[@id=\"UnitsInStock\"]")).GetAttribute("value");
            string uoo = driver.FindElement(By.XPath("//input[@id=\"UnitsOnOrder\"]")).GetAttribute("value");
            string rlevel = driver.FindElement(By.XPath("//input[@id=\"ReorderLevel\"]")).GetAttribute("value");
            IWebElement selectElemCat = driver.FindElement(By.Id("CategoryId"));
            SelectElement selectCat = new SelectElement(selectElemCat);
            string category = selectCat.SelectedOption.Text;
            IWebElement selectElemSup = driver.FindElement(By.Id("SupplierId"));
            SelectElement selectSup = new SelectElement(selectElemSup);
            string supplier = selectSup.SelectedOption.Text;
            Assert.AreEqual(category, "Meat/Poultry");
            Assert.AreEqual(supplier, "Grandma Kelly's Homestead");
            Assert.AreEqual(pname, "chiken legs");
            Assert.AreEqual(uprice, "100,0000");
            Assert.AreEqual(qpu, "12");
            Assert.AreEqual(uis, "200");
            Assert.AreEqual(uoo, "12");
            Assert.AreEqual(rlevel, "2");
            driver.FindElement(By.XPath("//a[text()=\"Products\"]")).Click();
        }

        [Test, Order(4)]
        public void Test4Delete()
        {
            driver.FindElement(By.XPath("//a[text()=\"chiken legs\"]/../following-sibling::*/a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000); //тк до проверки элемент не успевал исчезнуть после нажатия ОК на диалоговом окне
            Assert.IsFalse(isElementPresent(By.XPath("//table//a[text()=\"chiken legs\"]")));
        }

        [Test, Order(5)]
        public void Test5Logout()
        {
            driver.FindElement(By.XPath("//a[text()=\"Logout\"]")).Click();
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