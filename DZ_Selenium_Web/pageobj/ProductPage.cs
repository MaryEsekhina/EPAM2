﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DZ_Selenium_Web.pageobj
{
    class ProductPage
    {
        private IWebDriver driver;
        private IWebElement submitBtn => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement productsLink => driver.FindElement(By.XPath("//a[text()=\"Products\"]"));

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void InputValue(string id, string key)
        {
            driver.FindElement(By.Id(id)).SendKeys(key);
        }

        public void InputSelect (string id, string key)
        {
            IWebElement selectElem = driver.FindElement(By.Id(id));
            SelectElement select = new SelectElement(selectElem);
            select.SelectByValue(key);
        }

        public void submit()
        {
            submitBtn.Click();
        }

        public void ClickProducts()
        {
            productsLink.Click();
        }

        public string ReadValue(string id)
        {
            return driver.FindElement(By.XPath($"//input[@name=\"{id}\"]")).GetAttribute("value");
        }

        public string ReadSelect (string id)
        {
            IWebElement selectElem = driver.FindElement(By.Id(id));
            SelectElement select = new SelectElement(selectElem);
            return select.SelectedOption.Text;
        }
    }
}