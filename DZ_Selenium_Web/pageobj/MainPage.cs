using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DZ_Selenium_Web.pageobj
{
    class MainPage
    {
        private IWebDriver driver;
        public MainPage (IWebDriver driver)
        {
            this.driver=driver;

        }

       
        private IWebElement create => driver.FindElement(By.XPath("//div/a[text()=\"Create new\"]"));

        private IWebElement logout => driver.FindElement(By.XPath("//a[text()=\"Logout\"]"));

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

        public void Logout()
        {
            logout.Click();
        }
        public void DeleteProduct(string name)
        {
            driver.FindElement(By.XPath($"//a[text()=\"{name}\"]/../following-sibling::*/a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();
        }
    }
}
