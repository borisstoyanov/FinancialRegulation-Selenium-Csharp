using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.ExtRefInOut
{
    public class PO_ManageExtRefIn
    {
        public PO_ManageExtRefIn()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//li[@title='Click to Refresh Ext Ref Ins']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public void LinkRefIn(string refInType, string value)
        {
            SearchRefIn(Test.extRef, refInType);
            Link(value);
            VerifyCreatedOrRequested();
        }

        private void VerifyCreatedOrRequested()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("created", "requested");
        }

        private void Link(string value)
        {
            Browser.Browser.ClickByXPath("//input[@value='Link']");
            Util.WaitForElementVisibleByXPath("//div[text()='Link Ext Ref In to Valuation Source']", 15);
            Browser.Browser.Instance.FindElement(By.Id("SelectedEntity")).SendKeys(value);
            Util.WaitForElementVisibleByXPath("//li[text()='" + value + "']", 15);
            Browser.Browser.ClickByXPath("//li[text()='" + value + "']");
            Browser.Browser.ClickByID("applyLinkEntityBtn");

        }

        public void SearchRefIn(string searchTerm, string refInType)
        {
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(Test.extRef);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("Search_EMIRExtRefTypeSearch")))
                .SelectByText(refInType);
            Browser.Browser.ClickByID("EditExtRefIn");
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//div[text()='Showing 1 to 1 of 1 entries']", 2);
        }
    }


}
