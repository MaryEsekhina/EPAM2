using DZ_Selenium_Web.business_object;
using OpenQA.Selenium;
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
        public void ClickCreate()
        {
            create.Click();
        }

        public ProductPage OpenProduct(Product product)
        {
            driver.FindElement(By.XPath($"//a[text()=\"{product.productName}\"]")).Click();
            return new ProductPage(driver);
        }

        public LoginPage Logout()
        {
            logout.Click();
            return new LoginPage(driver);
        }
        public void DeleteProduct(Product product)
        {
            driver.FindElement(By.XPath($"//a[text()=\"{product.productName}\"]/../following-sibling::*/a[text()=\"Remove\"]")).Click();
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

        public bool IsProductPresent(string product)
        {
            return isElementPresent(By.XPath($"//table//a[text()=\"{product}\"]"));
        }

        public void WaitAllProducts(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(("//h2[text()=\"All Products\"]"))));
        }
    }
}
