using System;
using System.Collections.Generic;
using System.Text;
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

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void InputValue(string id, string key)
        {
            driver.FindElement(By.Id(id)).SendKeys(key);
        }

        public void submit()
        {
            new Actions(driver).MoveToElement(submitBtn).Click(submitBtn).Build().Perform();
  //          submitBtn.Click();
        }

        public MainPage ClickProducts()
        {
            productsLink.Click();
            return new MainPage(driver);
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

        public LoginPage Logout()
        {
            logout.Click();
            return new LoginPage(driver);
        }
    }
}
