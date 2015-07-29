using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ReferenceDatas_CreateReferenceDataPopUp
    {
        public PO_ReferenceDatas_CreateReferenceDataPopUp()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + ReferenceDataFieldIDs.Item_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(ReferenceDataFieldIDs.Item_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ReferenceDataFieldIDs.Item_Active))).SelectByText("Yes");
        }
        
        /*
        public PO_ReferenceDatas_CreateReferenceDataPopUp SetReferenceDataInputField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }
        */

        public PO_ReferenceDatas_CreateReferenceDataPopUp SetItem_Active(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ReferenceDataFieldIDs.Item_Active))).SelectByText(value);
            return this;
        }
        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
