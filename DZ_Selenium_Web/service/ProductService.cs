using DZ_Selenium_Web.business_object;
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
            productPage.InputProductName(product.productName);
            productPage.InputSupplierId(product.supplierId);
            productPage.InputCategoryId(product.categoryId);
            productPage.InputUnitPrice((product.unitPrice).ToString());
            productPage.InputQuantityPerUnit(product.quantityPerUnit);
            productPage.InputUnitsInStock(product.unitsInStock);
            productPage.InputUnitsOnOrder(product.unitsOnOrder);
            productPage.InputReorderLevel(product.reorderLevel);
            productPage.submit();
         }


        public Product ReadProduct(Product product, IWebDriver driver)
        {
            mainPage = new MainPage(driver);
            productPage = mainPage.OpenProduct(product);
            Product product2 = new Product
            {
                productName = productPage.ReadProductName(),
                quantityPerUnit = productPage.ReadQuantityPerUnit(),
                unitsInStock = productPage.ReadUnitsInStock(),
                unitsOnOrder = productPage.ReadUnitsOnOrder(),
                reorderLevel = productPage.ReadReorderLevel(),
                categoryId = productPage.ReadCategoryId(),
                supplierId = productPage.ReadSupplierId()
            };
            return product2;
        }

        public void DeleteProduct(Product product, IWebDriver driver)
        {
            productPage = new ProductPage(driver);
            mainPage = productPage.ClickProducts();
            mainPage.DeleteProduct(product);
            mainPage.WaitAllProducts(driver);
            
        }
    }
}
