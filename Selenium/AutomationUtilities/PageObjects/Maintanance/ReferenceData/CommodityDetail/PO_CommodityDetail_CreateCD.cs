using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_CommodityDetail_CreateCD
    {
        public PO_CommodityDetail_CreateCD()
        {

            try
            {

                Util.WaitForElementPresentByXPath("//*[text()='Create']", 60);

            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");

            }
            Util.WaitForElementVisibleByXPath("//input[@id='" + CommodityDetailFieldIDs.Name + "']", 15);
            SetInputField(CommodityDetailFieldIDs.Name, Test.extRef = "TA" + Util.GetRandomID());
            Select(CommodityDetailFieldIDs.CommodityBase, "Index");            
        }


        public PO_CommodityDetail_CreateCD SetInputField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }


        public PO_CommodityDetail_CreateCD Select(String fieldID, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(fieldID))).SelectByText(value);
            return this;
        }



        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
