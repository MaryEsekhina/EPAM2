﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DZ_Selenium_Web.pageobj
{
    class MainPage
    {
        private IWebDriver driver;
      
        private IWebElement create => driver.FindElement(By.XPath("//div/a[text()=\"Create new\"]"));

        private IWebElement logout => driver.FindElement(By.XPath("//a[text()=\"Logout\"]"));

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;

        }
        public ProductPage CreateProduct()
        {
            create.Click();
            return new ProductPage(driver);
        }

        public ProductPage OpenProduct(string name)
        {
            driver.FindElement(By.XPath($"//a[text()=\"{name}\"]")).Click();
            return new ProductPage(driver);
        }

        public LoginPage Logout()
        {
            logout.Click();
            return new LoginPage(driver);
        }
        public void DeleteProduct(string name)
        {
            driver.FindElement(By.XPath($"//a[text()=\"{name}\"]/../following-sibling::*/a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();
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

        public bool IsProductPresent(string name, IWebDriver driver)
        {
            return isElementPresent(By.XPath($"//table//a[text()=\"{name}\"]"));
        }

        public void WaitAllProducts(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(("//h2[text()=\"All Products\"]"))));
        }
    }
}
