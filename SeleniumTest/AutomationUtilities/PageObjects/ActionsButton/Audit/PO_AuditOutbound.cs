using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationUtilities.PageObjects.Audit
{
    public class PO_AuditOutboundPopUp
    {
        public PO_AuditOutboundPopUp()
        {
            try
            {
                Util.WaitForElementVisibleByXPath("//a[contains(text(),'Outbound Audit Entries')]", 60);
                Util.WaitForElementVisibleByXPath("//div[contains(text(),'entries')]", 120);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public string GetAuditsCountMsg()
        {
            Thread.Sleep(2000);
            return Browser.Browser.Instance.FindElement(By.ClassName("dataTables_info")).Text;
        }

        public void Close()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        public string GetLatestResponse()
        {
            return Browser.Browser.Instance.FindElement(By.XPath("//tr[@class='odd']//td[3]")).Text;
        }

        public void CheckIfRefernceIsVisible(string reference)
        {
            Util.CheckIfTextPresented(reference);
        }

        public void CheckIfRefernceIsNotVisible(string reference)
        {
            Util.CheckIfTextNotPresented(reference);
        }
    }
}
