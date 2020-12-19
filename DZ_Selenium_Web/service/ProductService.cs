﻿using DZ_Selenium_Web.business_object;
using DZ_Selenium_Web.pageobj;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_Selenium_Web.service
{
    class ProductService
    {
        ProductPage productPage;
        MainPage mainPage;

        public void InputProduct(Product product, IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            mainPage = homePage.ClickLink("All Products");
            productPage = mainPage.CreateProduct();
            productPage.InputValue("ProductName", product.productName);
            IWebElement selectElem = driver.FindElement(By.Id("CategoryId"));
            SelectElement select = new SelectElement(selectElem);
            select.SelectByText(product.categoryId);
            selectElem = driver.FindElement(By.Id("SupplierId"));
            select = new SelectElement(selectElem);
            select.SelectByText(product.supplierId);
            productPage.InputValue("UnitPrice", (product.unitPrice).ToString());
            productPage.InputValue("QuantityPerUnit", product.quantityPerUnit);
            productPage.InputValue("UnitsInStock", product.unitsInStock);
            productPage.InputValue("UnitsOnOrder", product.unitsOnOrder);
            productPage.InputValue("ReorderLevel", product.reorderLevel);
            productPage.submit();
         }

        public Product ReadProduct(Product product, IWebDriver driver)
        {
            mainPage = new MainPage(driver);
            productPage = mainPage.OpenProduct(product);
            Product product2 = new Product();
            product2.productName = productPage.ReadValue("ProductName");
            product2.unitPrice = float.Parse(productPage.ReadValue("UnitPrice"));
            product2.quantityPerUnit = productPage.ReadValue("QuantityPerUnit");
            product2.unitsInStock = productPage.ReadValue("UnitsInStock");
            product2.unitsOnOrder = productPage.ReadValue("UnitsOnOrder");
            product2.reorderLevel = productPage.ReadValue("ReorderLevel");
            product2.categoryId = productPage.ReadSelect("CategoryId");
            product2.supplierId = productPage.ReadSelect("SupplierId");
            return product2;
        }

        public void DeleteProduct(Product product, IWebDriver driver)
        {
            productPage = new ProductPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            mainPage = productPage.ClickProducts();
            mainPage.DeleteProduct(product);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(("//h2[text()=\"All Products\"]"))));
        }
    }
}