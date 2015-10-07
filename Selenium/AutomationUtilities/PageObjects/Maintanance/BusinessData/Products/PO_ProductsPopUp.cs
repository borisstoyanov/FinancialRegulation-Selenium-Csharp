using AutomationUtilities.PageObjects.Products;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ProductsPopUp
    {
        public PO_ProductsPopUp()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h3[text()='Search']", 15);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
                Test.TearDown(true);
            }
        }


        public PO_Products_CreateProductPopUp CreateNewProduct()
        {
            ClickCreate();
            return new PO_Products_CreateProductPopUp();
        }

        private void ClickCreate()
        {
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            Thread.Sleep(2000);
        }

        public void VerifyProductIsCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been created", "has been requested");
        }

        public void VerifyProductIsFound(string productName)
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented(Test.extRef);
        }

        public PO_Products_EditProductPopUp EditProduct()
        {
            SearchForProduct(Test.extRef);
            ClickEdit();
            return new PO_Products_EditProductPopUp();
        }
        private void ClickEdit()
        {
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Edit");
            Thread.Sleep(2000);
        }

        public void SearchForProduct(string productName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).Clear();
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(productName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void VerifyProductIsEditted()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been created", "has been requested");
        }

        public void CloseWindow()
        {
            Browser.Browser.ClickClose();
        }

        public PO_Products_ViewProduct ViewDetails()
        {
            SearchForProduct(Test.extRef);
            ClickViewDetails();
            return new PO_Products_ViewProduct();
        }

        private void ClickViewDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }

        public void WaitForProductImport(int timeout)
        {
            for (int i = 0; i <= timeout; i++)
            {
                SearchForProduct(Test.extRef);
                Thread.Sleep(5000);
                if (Util.IsElementPresent(By.XPath("//select[contains(@onchange,'submitMyAction')]")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Product was not imported successfully");
                        Assert.Fail("Product was not imported successfully");
                    }
                }
            }
        }

        public void VerifyCounterPartyIsNotFound()
        {
            SearchForProduct(Test.extRef);
            if (!Util.IsElementPresent(By.XPath("//td[contains(@class,'dataTables_empty')]")))
            {
                Assert.Fail("Product was found");
            }
        }
    }
}
