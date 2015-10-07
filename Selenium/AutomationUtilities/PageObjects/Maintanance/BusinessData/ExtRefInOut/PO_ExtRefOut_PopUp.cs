using AutomationUtilities.PageObjects.ExtRefInOut;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ExtRefOut_PopUp
    {
        public PO_ExtRefOut_PopUp()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//span[@class='ui-dialog-title'][text()='Ext Ref Outs']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");

            }
        }



        public PO_ExtRefOut_CreateRefOut ClickCreate()
        {
            Util.WaitForElementPresentByXPath("//a[text()='Create']", 15);
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            return new PO_ExtRefOut_CreateRefOut();
        }

        public void VerifyExtRefOutIsCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("has been created");
        }

        public void ClosePopUp()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        public void ChangeTradeRepo(String repo)
        {
            SearchForExtRefOut(Test.extRef);
            SelectEdit();
            Util.WaitForElementPresentByXPath("//h2[contains(text(),'Edit " + Test.extRef + " Created ')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("EMIRExtRefOut_TradeRepository"))).SelectByText(repo);
            Browser.Browser.ClickByID("Save");
        }

        private void SelectEdit()
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]")))
                .SelectByText("Edit");
            Thread.Sleep(2000);
        }

        public void SearchForExtRefOut(string id)
        {
            Thread.Sleep(3000);
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(Test.extRef);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//div[text()='Showing 1 to 1 of 1 entries']", 2);


        }

        public void VerifyExtRefOutIsEdited()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("has been edited");
        }

        public PO_ExtRefOut_ViewDetails ViewRefOut()
        {
            SearchForExtRefOut(Test.extRef);
            ClickDetails();
            return new PO_ExtRefOut_ViewDetails();
        }
        
        private void ClickDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }

        public PO_ExtRefOut_EditRefOut EditRefOut()
        {
            SearchForExtRefOut(Test.extRef);
            SelectEdit();
            return new PO_ExtRefOut_EditRefOut();
        }

        public void SearchForExtRefOut_ByReference(string searchTerm)
        {
            Browser.Browser.Instance.FindElement(By.Id("Search_ReferenceSearch")).SendKeys(searchTerm);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void SelectTodayDateAndSearch()
        {
            Browser.Browser.Instance.FindElement(By.Id("CreatedSearch")).SendKeys(DateTime.Now.ToString("dd/MM/yyyy"));
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public PO_ExtRefOut_PopUp SetTypeSelectField(String field, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(field))).SelectByText(value);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
            return this;
        }
    }
}
