using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ExtRefIn_CreateRefIn
    {
        public PO_ExtRefIn_CreateRefIn()
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

        }
        public void CreateExtRef(string refType, string sourceSystem)
        {
            Thread.Sleep(4000);
            Util.WaitForElementVisibleByXPath("//input[@id='" + ExtRefIns.EMIRExtRefIn_Reference + "']", 5);
            Browser.Browser.Instance.FindElement(By.Id(ExtRefIns.EMIRExtRefIn_Reference)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Browser.Browser.ClickByID(ExtRefIns.EMIRExtRefIn_Name);
            Browser.Browser.Instance.FindElement(By.Id(ExtRefIns.EMIRExtRefIn_Name)).SendKeys(Test.extRef);
            SelectRefType(refType);
            SelectSourceSystem(sourceSystem);
            Browser.Browser.ClickByID("Save");
        }


        private void SelectRefType(string refType)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ExtRefIns.EMIRExtRefIn_EMIRExtRefType))).SelectByText(refType);
        }
        private void SelectSourceSystem(string sourceSystem)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ExtRefIns.EMIRExtRefIn_EMIRSourceSystem))).SelectByText(sourceSystem);
        }


    }
}
