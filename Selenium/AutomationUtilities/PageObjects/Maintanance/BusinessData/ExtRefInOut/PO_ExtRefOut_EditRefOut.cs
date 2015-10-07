using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.ExtRefInOut
{
    public class PO_ExtRefOut_EditRefOut
    {
        public PO_ExtRefOut_EditRefOut()
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

        public PO_ExtRefOut_EditRefOut SetField(String ExtRefOuts, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(ExtRefOuts)).SendKeys(value);
            return this;
        }

        public PO_ExtRefOut_EditRefOut SelectField(String ExtRefOuts, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ExtRefOuts))).SelectByText(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }

    }
}
