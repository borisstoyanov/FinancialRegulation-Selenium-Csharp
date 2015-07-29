using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationUtilities.PageObjects.Maintanance.BusinessData.EicCodes
{
    public class PO_EIC_EditEIC
    {
        public PO_EIC_EditEIC()
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

        public PO_EIC_EditEIC SetEicCideField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }

        public PO_EIC_EditEIC SelectField(String field, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(field))).SelectByText(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
