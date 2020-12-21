using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DZ_Selenium_Web.pageobj
{
    class ProductPage
    {
        private IWebDriver driver;
        public IWebElement submitBtn => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement productsLink => driver.FindElement(By.XPath("//a[text()=\"Products\"]"));
        private IWebElement logout => driver.FindElement(By.XPath("//a[text()=\"Logout\"]"));
        private IWebElement productName => driver.FindElement(By.XPath($"//input[@name=\"ProductName\"]"));
        private IWebElement unitPrice => driver.FindElement(By.XPath($"//input[@name=\"UnitPrice\"]"));
        private IWebElement quantityPerUnit => driver.FindElement(By.XPath($"//input[@name=\"QuantityPerUnit\"]"));
        private IWebElement unitsInStock => driver.FindElement(By.XPath($"//input[@name=\"UnitsInStock\"]"));
        private IWebElement unitsOnOrder => driver.FindElement(By.XPath($"//input[@name=\"UnitsOnOrder\"]"));
        private IWebElement reorderLevel => driver.FindElement(By.XPath($"//input[@name=\"ReorderLevel\"]"));
        private IWebElement selectCategoryId => driver.FindElement(By.Id("CategoryId"));
        private IWebElement selectSupplierId => driver.FindElement(By.Id("SupplierId"));

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void InputProductName(string key)
        {
            productName.SendKeys(key);
        }
        public void InputUnitPrice(string key)
        {
            unitPrice.SendKeys(key);
        }
        public void InputQuantityPerUnit(string key)
        {
            quantityPerUnit.SendKeys(key);
        }
        public void InputUnitsInStock(string key)
        {
            unitsInStock.SendKeys(key);
        }
        public void InputUnitsOnOrder(string key)
        {
            unitsOnOrder.SendKeys(key);
        }
        public void InputReorderLevel(string key)
        {
            reorderLevel.SendKeys(key);
        }

        public void InputCategoryId(string value)
        {
            SelectElement select = new SelectElement(selectCategoryId);
            select.SelectByText(value);
        }
        public void InputSupplierId(string value)
        {
            SelectElement select = new SelectElement(selectSupplierId);
            select.SelectByText(value);
        }

        public string ReadProductName()
        {
            return productName.GetAttribute("value");
        }

        public string ReadUnitPrice()
        {
            return unitPrice.GetAttribute("value");
        }

        public string ReadQuantityPerUnit()
        {
            return quantityPerUnit.GetAttribute("value");
        }

        public string ReadUnitsInStock()
        {
            return unitsInStock.GetAttribute("value");
        }

        public string ReadUnitsOnOrder()
        {
            return unitsOnOrder.GetAttribute("value");
        }

        public string ReadReorderLevel()
        {
            return reorderLevel.GetAttribute("value");
        }

        public string ReadCategoryId()
        {
            SelectElement select = new SelectElement(selectCategoryId);
            return select.SelectedOption.Text;
        }

        public string ReadSupplierId()
        {
            SelectElement select = new SelectElement(selectSupplierId);
            return select.SelectedOption.Text;
        }
        public void submit()
        {
            submitBtn.Click();
        }

        public void ClickProducts()
        {
            productsLink.Click();
        }

      
        public LoginPage Logout()
        {
            logout.Click();
            return new LoginPage(driver);
        }
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

        public bool IsSubmitPresent(IWebDriver driver)
        {
            return isElementPresent(By.XPath("//input[@type=\"submit\"]"));
        }
    }
}
