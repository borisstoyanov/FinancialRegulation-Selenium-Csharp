using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_CounterParty_EditCP
    {
        public PO_CounterParty_EditCP()
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
        public PO_CounterParty_EditCP SetCounterPartyInputField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }

        public PO_CounterParty_EditCP SetCounterPartySelectField(String field, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(field))).SelectByText(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }


        public void VerifyIntragroupNotPresent()
        {
            Util.WaitForElementNotVisibleByXPath("Intragroup", 15);
        }
    }
}
