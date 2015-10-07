using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationUtilities.PageObjects.Maintanance.ReferenceData.InitiatorAggressor
{
    public class PO_InitiatorAggressor_Edit
    {
        public PO_InitiatorAggressor_Edit()
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

        public PO_InitiatorAggressor_Edit SetInitiatorAggressorField(string fieldId, string value)
        {
            var field = Browser.Browser.Instance.FindElement(By.Id(fieldId));
            field.Clear();
            field.SendKeys(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
