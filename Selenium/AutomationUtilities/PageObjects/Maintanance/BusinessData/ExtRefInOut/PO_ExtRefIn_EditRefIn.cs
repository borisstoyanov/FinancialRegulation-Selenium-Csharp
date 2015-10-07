using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.ExtRefInOut
{
    public class PO_ExtRefIn_EditRefIn
    {
        public PO_ExtRefIn_EditRefIn()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//input[@id='Save']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public PO_ExtRefIn_EditRefIn SetField(String ExtRefIns, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(ExtRefIns)).SendKeys(value);
            return this;
        }

        public PO_ExtRefIn_EditRefIn SelectField(String ExtRefIns, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ExtRefIns))).SelectByText(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
