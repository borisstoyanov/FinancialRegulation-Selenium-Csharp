using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.Markets
{
    public class PO_Markets_Create : MarketFields
    {
        public PO_Markets_Create()
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
            Browser.Browser.Instance.FindElement(By.Id(Market_Name))
                .SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Browser.Browser.Instance.FindElement(By.Id(Market_MIC))
                .SendKeys(Test.extRef.Remove(Test.extRef.Length - 3));
            SelectField(MarketFields.Market_OfficialMarketPlace, "True");
           

        }
        public PO_Markets_Create SetField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field))
                 .SendKeys(value);
            return this;
        }

        public PO_Markets_Create SelectField(String field, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(field)))
                .SelectByValue(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
