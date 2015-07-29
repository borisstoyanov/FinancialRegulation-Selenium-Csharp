using AutomationUtilities.Exceptions;
using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ChannelFileMasks_Edit
    {
        public PO_ChannelFileMasks_Edit()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//input[@id='Save']", 60);
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public PO_ChannelFileMasks_Edit SetChannelFileMasksField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }

        public PO_ChannelFileMasks_Edit SetName(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ChannelFileMasksFieldIDs.FileDateFormat))).SelectByText(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
