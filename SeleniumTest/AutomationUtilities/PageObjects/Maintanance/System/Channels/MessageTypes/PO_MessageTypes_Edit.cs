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
    public class PO_MessageTypes_Edit
    {
        public PO_MessageTypes_Edit()
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

        public PO_MessageTypes_Edit SetMessageTypesField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }

        public PO_MessageTypes_Edit SetName(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(MessageTypesFieldIDs.Item_Name))).SelectByText(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
