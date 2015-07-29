using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ExtRefOut_CreateRefOut
    {
        public PO_ExtRefOut_CreateRefOut()
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
        
        }
        public void CreateExtRef(string refType, string tradeRepo)
        {
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//form[@id='EMIRExtRefOutCreate']//input[@id='EMIRExtRefOut_Reference']", 5);
            Browser.Browser.Instance.FindElement(By.XPath("//form[@id='EMIRExtRefOutCreate']//input[@id='EMIRExtRefOut_Reference']")).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Browser.Browser.ClickByXPath("//input[@name='EMIRExtRefOut.Name']");
            Browser.Browser.Instance.FindElement(By.XPath("//input[@name='EMIRExtRefOut.Name']")).SendKeys(Test.extRef);
            SelectRefType(refType);
            SelectSourceSystem(tradeRepo);
            Browser.Browser.ClickByID("Save");
        }


        private void SelectRefType(string refType)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("EMIRExtRefOut_EMIRExtRefType"))).SelectByText(refType);
        }
        private void SelectSourceSystem(string tradeRepo)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("EMIRExtRefOut_TradeRepository"))).SelectByText(tradeRepo);
        }

        
    }
}
