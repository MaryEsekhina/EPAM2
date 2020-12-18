using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace DZ_Selenium_Web.pageobj
{
    class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public MainPage ClickLink(string link)
        {
            driver.FindElement(By.XPath($"//div/div/a[text()=\"{link}\"]")).Click();
            return new MainPage(driver);
        }


    }
}
