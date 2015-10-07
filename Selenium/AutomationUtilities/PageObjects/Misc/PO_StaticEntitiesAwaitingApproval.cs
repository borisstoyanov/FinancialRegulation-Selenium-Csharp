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

namespace AutomationUtilities.PageObjects
{
    public class PO_StaticEntitiesAwaitingApproval
    {
        public PO_StaticEntitiesAwaitingApproval()
        {
            Thread.Sleep(2000);
            String expectedPage = "Static Entities Awaiting Approval";
            String actualPage = Browser.Browser.Instance.Title.ToString();

            try
            {

                if (!expectedPage.Equals(actualPage))
                {
                    throw new NotOnTheExpectedPageException(expectedPage, actualPage);
                }
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one. \nExpected this: " + e.getExpectedPage() + "\nbut got this: " + e.getActualPage());
                Test.TearDown(true);
            }
        }


        public void ApproveStaticEntitie(string extRefID)
        {
            FindExtRefID(extRefID);
            Approve();
        }

        public void DeclineStaticEntitie(string extRefID)
        {
            FindExtRefID(extRefID);
            Decline();
        }

        private void Decline()
        {
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Approval");
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//title[contains(text(),'Approval for " + Test.extRef + "')]", 10);
            Browser.Browser.Instance.FindElement(By.Id("AuditNote")).SendKeys("Rejected");
            Browser.Browser.ClickByID("Reject");
            Thread.Sleep(2000);
        }

        private void Approve()
        {
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Approval");
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//title[contains(text(),'Approval for " + Test.extRef + "')]", 10);
            Browser.Browser.ClickByID("Approve");
            Thread.Sleep(2000);
        }

        private void FindExtRefID(string extRefID)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(extRefID+"*");
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
