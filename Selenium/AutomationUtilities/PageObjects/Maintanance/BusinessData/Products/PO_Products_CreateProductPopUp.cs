using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_Products_CreateProductPopUp
    {
        public PO_Products_CreateProductPopUp()
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
            Util.WaitForElementVisibleByXPath("//*[@id='" + ProductInputFields.EMIRProduct_Name + "']", 15);
            Browser.Browser.ClickByID(ProductInputFields.EMIRProduct_Name);
            Browser.Browser.Instance.FindElement(By.Id(ProductInputFields.EMIRProduct_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ProductSelectFields.EMIRProduct_Percentage))).SelectByText("Yes");
            SetProductSelectField(ProductSelectFields.EMIRProduct_DerivativeClassExtRefIn, "Commodity (Commodity, EMIR, Manual, Derivative Class, 31 Jan 2014) - Commodity");
            SetProductSelectField(ProductSelectFields.EMIRProduct_DerivativeTypeExtRefIn, "Other (Other, EMIR, Manual, Derivative Type, 31 Jan 2014) - Other");
            SetProductSelectField(ProductSelectFields.EMIRProduct_ProductTaxonomyExtRefIn, "TestTaxonomy (TestTaxonomy, EMIR, Manual, Product Taxonomy, 10 Feb 2014) - ISIN/AII + CFI");

        }
        public PO_Products_CreateProductPopUp SetProductInputField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }

        public PO_Products_CreateProductPopUp SetProductSelectField(String field, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(field))).SelectByText(value);
            return this;
        }
        public void Create()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
