using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace DZ_Selenium_Web.pageobj
{
    class HomePage
    {
        private IWebDriver driver;
        private IWebElement logout => driver.FindElement(By.XPath("//a[text()=\"Logout\"]"));
        private IWebElement title => driver.FindElement(By.XPath("//h2"));
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public MainPage ClickLink(string link)
        {
            driver.FindElement(By.XPath($"//div/div/a[text()=\"{link}\"]")).Click();
            return new MainPage(driver);
        }

        public string TitleText()
        {
            return title.Text;
        }
        public LoginPage Logout()
        {
            logout.Click();
            return new LoginPage(driver);
        }
    }
}
