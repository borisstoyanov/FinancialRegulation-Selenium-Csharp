using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ActionTypes_CreateActionTypePopUp
    {
        public PO_ActionTypes_CreateActionTypePopUp()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//span[@class='ui-dialog-title'][text()='Create']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");

            }
            Util.WaitForElementVisibleByXPath("//input[@id='" + ActionTypeFieldIDs.Item_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(ActionTypeFieldIDs.Item_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ActionTypeFieldIDs.Item_Active))).SelectByText("Yes");
        }

        /*
        public PO_ReferenceDatas_CreateReferenceDataPopUp SetReferenceDataInputField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }
        */

        public PO_ActionTypes_CreateActionTypePopUp SetItem_Active(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ActionTypeFieldIDs.Item_Active))).SelectByText(value);
            return this;
        }
        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
