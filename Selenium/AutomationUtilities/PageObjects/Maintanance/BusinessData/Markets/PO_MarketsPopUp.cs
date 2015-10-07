using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.Markets
{
    public class PO_MarketsPopUp
    {
        public PO_MarketsPopUp()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h3[text()='Search']", 15);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
                Test.TearDown(true);
            }
        }

        public PO_Markets_Create CreateMarket()
        {
            ClickCreate();
            return new PO_Markets_Create();
        }

        private void ClickCreate()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//a[text()='Create']", 10);
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            Thread.Sleep(2000);
        }

        public void VerifyMarketCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been created", "has been requested");
        }

        public void Close()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        public PO_Markets_Edit EditMarket()
        {
            SearchForMarket(Test.extRef);
            SelectEdit();
            return new PO_Markets_Edit();
        }

        private void SelectEdit()
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]")))
                .SelectByText("Edit");
            Thread.Sleep(2000);
        }

        public void SearchForMarket(string searchTerm)
        {
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(searchTerm);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void VerifyMarketIsEdited()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("has been edited");
        }

        public PO_Markets_ViewDetails ViewMarketDetails()
        {
            SearchForMarket(Test.extRef);
            ClickDetails();
            return new PO_Markets_ViewDetails();
        }

        private void ClickDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }

        public PO_Markets_ViewAudits ViewAudits()
        {
            SearchForMarket(Test.extRef);
            ClickViewAudits();
            return new PO_Markets_ViewAudits();
        }

        private void ClickViewAudits()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("View Audit Entries");
            Thread.Sleep(2000);
        }

        public PO_Markets_ViewCounterparty ViewCounterparty()
        {
            SearchForMarket(Test.extRef);
            ClickViewCounterpary();
            return new PO_Markets_ViewCounterparty();
        }

        private void ClickViewCounterpary()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("View Central Counterparty");
            Thread.Sleep(2000);
        }

        public void SearchForMarketByMIC(string searchTerm)
        {
            Browser.Browser.Instance.FindElement(By.Id("Search_MICSearch")).SendKeys(searchTerm);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }
    }
}
