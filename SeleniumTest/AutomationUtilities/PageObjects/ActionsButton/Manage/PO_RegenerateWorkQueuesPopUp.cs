using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_RegenerateWorkQueuesPopUp
    {
        public PO_RegenerateWorkQueuesPopUp()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h2[text()='Regenerate Work Queues']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public void RegenerateWorkQueues()
        {
            ClickegenerateWorkQueues();
        }

        private void ClickegenerateWorkQueues()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//input[@id='RegenerateAll']", 10);
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//input[@id='RegenerateAll']");
            Thread.Sleep(30000);
        }

        public void VerifyWorkQueueGenerated()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("Operation completed successfully. Please, refresh your home page to reload the dashboard work queues!");
        }
    }
}
