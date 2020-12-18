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
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement logName => driver.FindElement(By.Id("Name"));
        private IWebElement logPass => driver.FindElement(By.Id("Password"));
        private IWebElement logBtn => driver.FindElement(By.CssSelector(".btn"));


        public void Login(string name, string pass)
        {
            new Actions(driver).SendKeys(logName, name).Build().Perform();
            // logName.SendKeys(name);
            new Actions(driver).SendKeys(logPass, pass).Build().Perform();
            //logPass.SendKeys(pass);
            new Actions(driver).MoveToElement(logBtn).Click(logBtn).Build().Perform();
           // logBtn.Click();
        }

        
    }
}
