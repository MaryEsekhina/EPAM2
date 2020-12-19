using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DZ_Selenium_Web.pageobj
{
    class LoginPage
    {
        private IWebDriver driver;
        private IWebElement logout => driver.FindElement(By.XPath("//a[text()=\"Logout\"]"));
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement logName => driver.FindElement(By.Id("Name"));
        private IWebElement logPass => driver.FindElement(By.Id("Password"));
        private IWebElement logBtn => driver.FindElement(By.CssSelector(".btn"));


        public HomePage Login(string name, string pass)
        {
            new Actions(driver).SendKeys(logName, name).Build().Perform();
            new Actions(driver).SendKeys(logPass, pass).Build().Perform();
            new Actions(driver).MoveToElement(logBtn).Click(logBtn).Build().Perform();
            return new HomePage(driver);
        }

        public string TitleText()
        {
            return driver.FindElement(By.XPath("//h2")).Text;
        }
        
    }
}
