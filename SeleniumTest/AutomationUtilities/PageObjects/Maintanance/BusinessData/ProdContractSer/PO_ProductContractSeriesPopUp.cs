using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.Maintanance.BusinessData.ProdContractSer
{
    public class PO_ProductContractSeriesPopUp
    {
        public PO_ProductContractSeriesPopUp()
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


        public PO_ProductContractSeries_Create CreateNewProduct()
        {
            ClickCreate();
            return new PO_ProductContractSeries_Create();
        }

        private void ClickCreate()
        {
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            Thread.Sleep(2000);
        }

        public void VerifyProductSeriesIsCreated()
        {
            SearchForProductSeries(Test.extRef);
            Util.CheckIfTextPresented(Test.extRef);
        }

        public void VerifyProductIsFound(string productName)
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented(Test.extRef);
        }

        public PO_ProductContractSeries_Edit EditProductSeries()
        {
            SearchForProductSeries(Test.extRef);
            ClickEdit();
            return new PO_ProductContractSeries_Edit();
        }
        private void ClickEdit()
        {
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Edit");
            Thread.Sleep(2000);
        }

        public void SearchForProductSeries(string productName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_ContractId")).Clear();
            Browser.Browser.Instance.FindElement(By.Id("Search_ContractId")).SendKeys(productName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void VerifyProductSeriesIsEditted()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented(Test.extRef);
        }

        public void CloseWindow()
        {
            Browser.Browser.ClickClose();
        }

        public PO_ProductContractSeries_View ViewDetails()
        {
            SearchForProductSeries(Test.extRef);
            ClickViewDetails();
            return new PO_ProductContractSeries_View();
        }

        private void ClickViewDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }



        public void VerifyMandatoryFieldsValidationError()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("Invalid Product Contract Series");
        }

        public void VerifyIncorrectFieldInput()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("The Series ID should contain only alpha numerical characters");
        }
    }
}
