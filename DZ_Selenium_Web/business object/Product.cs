using System;
using System.Collections.Generic;
using System.Text;

namespace DZ_Selenium_Web.business_object
{
    class Product
    {

        public string productName;
        public float unitPrice;
        public string quantityPerUnit;
        public string unitsInStock;
        public string unitsOnOrder;
        public string reorderLevel;
        public string categoryId;
        public string supplierId;

        public Product(string productName, string categoryId, string supplierId, float unitPrice, string quantityPerUnit, string unitsInStock, string unitsOnOrder, string reorderLevel)
        {
            this.productName = productName;
            this.unitPrice = unitPrice;
            this.quantityPerUnit = quantityPerUnit;
            this.unitsInStock = unitsInStock;
            this.unitsOnOrder = unitsOnOrder;
            this.reorderLevel = reorderLevel;
            this.categoryId = categoryId;
            this.supplierId = supplierId;
        }
        public Product()
        { }
    }
}
