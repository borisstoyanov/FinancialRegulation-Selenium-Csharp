using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_EntityLocksPopUp
    {
        public PO_EntityLocksPopUp()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h3[text()='Search']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public void RemoveLock()
        {
            ClickRemoveLock();
        }

        public void Close()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        public string GetEntityLockCountMsg()
        {
            Thread.Sleep(2000);
            return Browser.Browser.Instance.FindElement(By.ClassName("dataTables_info")).Text;
        }

        private void ClickRemoveLock()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Remove Lock");
            Thread.Sleep(2000);
        }

        public void VerifyLockRemoved()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("Lock removed");
        }

        public void SearchEntityLockType(string actionTypeName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_EntityTypeSearch")).SendKeys(actionTypeName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void SearchEntityLockUniqueReference(string actionTypeName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_UniqueReferenceSearch")).SendKeys(actionTypeName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void SearchEntityLockLockedBy(string actionTypeName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_LockedBySearch")).SendKeys(actionTypeName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }
    }
}
