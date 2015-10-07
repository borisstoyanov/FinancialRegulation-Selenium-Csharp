using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.Maintanance.BusinessData.ProdContractSer
{
    public class PO_ProductContractSeries_Create
    {
        public PO_ProductContractSeries_Create()
        {
            
            try
            {
                Util.WaitForElementPresentByXPath("//span[@class='ui-dialog-title'][text()='Create']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
                Test.TearDown(true);
            }
            Util.WaitForElementVisibleByXPath("//*[@id='ProductContractSeries_ContractId']", 15);
            Browser.Browser.Instance.FindElement(By.Id("ProductContractSeries_ContractId")).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("ProductContractSeries_EMIRProductID")))
                .SelectByText("Manual Commodity Option");
                

        }
        public PO_ProductContractSeries_Create SetProductInputField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }

        public PO_ProductContractSeries_Create SetProductSelectField(String field, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(field))).SelectByText(value);
            return this;
        }
        public void Create()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }

        public PO_ProductContractSeries_Create CleanField(string p)
        {
            Browser.Browser.Instance.FindElement(By.Id(p)).Clear();
            return this;
        }
    }
}
