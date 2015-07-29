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
    public class PO_EMIRSettings
    {
        public PO_EMIRSettings()
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

        public PO_EMIRSettings SetBaseCurrency(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(EMIRSettingsFieldIDs.EMIRSettings_BaseCurrency))).SelectByText(value);
            return this;
        }

        public PO_EMIRSettings SetCountryName(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(EMIRSettingsFieldIDs.EMIRSettings_CountryName))).SelectByText(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }

        public void VerifyEMIRSettings()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been edited", "has been requested");
        }

    }
}
