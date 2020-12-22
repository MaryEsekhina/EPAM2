using System;
using System.Collections.Generic;
using System.Text;
using DZ_Selenium_Web.business_object;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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



        public void InputCategoryId(Product product)
        {
            SelectElement select = new SelectElement(selectCategoryId);
            select.SelectByText(product.categoryId);
        }
        public void InputSupplierId(Product product)
        {
            SelectElement select = new SelectElement(selectSupplierId);
            select.SelectByText(product.supplierId);
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
            new Actions(driver).MoveToElement(submitBtn).Click(submitBtn).Build().Perform();

        }

        public MainPage ClickProducts()
        {
            productsLink.Click();
            return new MainPage(driver);
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

        public bool IsSubmitPresent()
        {
            return isElementPresent(By.XPath("//input[@type=\"submit\"]"));
        }
    }
}
