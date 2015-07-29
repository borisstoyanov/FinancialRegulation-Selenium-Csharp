using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_InboundSourcesPopUp
    {
        public PO_InboundSourcesPopUp()
        {
            try
            {
                Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/SourcesInbound')]", 60);
        //        Util.WaitForElementPresentByXPath("//h3[text()='Inbound Sources']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public static PO_InboundSourcesPopUp GoToInboundSources()
        {
            PO_ActionButton.GoToInboundSources();
            return new PO_InboundSourcesPopUp();
        }

        public static void SearchForSource(string searchTerm)
        {
            Browser.Browser.ClickByXPath("//div[contains(@id,'_FilterToggle')]");
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Reference Id']")).SendKeys(searchTerm);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Reference Id']")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            Util.CheckIfTextPresented("Showing 0 to 0 of 0 entries");
        }

        public static string GetFirstSource()
        {
            IWebElement thisElement = Browser.Browser.Instance.FindElement(By.XPath("//table[contains(@id,'ImpendiumGridTable')]//tbody//tr[1]//td[2]"));
            return thisElement.Text;
        }

        public static void CheckNoEntries()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("Showing 0 to 0 of 0 entries");
            Thread.Sleep(2000);
        }
    }
}
