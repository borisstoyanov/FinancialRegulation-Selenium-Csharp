using AutomationUtilities.PageObjects.CounterPartiesPO;
using AutomationUtilities.PageObjects.Maintanance.BusinessData.CounterParties;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_CounterParties_PopUp
    {
        public PO_CounterParties_PopUp()
        {
            
            try
            {

                Util.WaitForElementPresentByXPath("//h3[text()='Search']", 15);
                
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        
        }
        public PO_CounterParty_CreateCP_PopUp CreateNewCounterParty()
        {
            ClickCreate();
 	        return new PO_CounterParty_CreateCP_PopUp();
        }

        private void ClickCreate()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//a[text()='Create']", 10); 
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            Thread.Sleep(2000);
        }

        public void VerifyCounterPartyIsCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been created", "has been requested");
        }

        public PO_CounterParty_EditCP EditCounterParty()
        {
            SearchCP(Test.extRef);
            ClickEditCP();
            return new PO_CounterParty_EditCP();
        }

        private void ClickEditCP()
        {
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Edit");
            Thread.Sleep(2000);
        }

        public void SearchCP(string counterPartyName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(counterPartyName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void VerifyCounterPartyIsChanged()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("has been edited");
        }

        public void ClosePopUp()
        {
            Browser.Browser.ClickClose();
        }

        public PO_CounterParty_ViewMarkets ViewMarkets()
        {
            SearchCP(Test.extRef);
            ClickViewMarkets();
            return new PO_CounterParty_ViewMarkets();
        }

        private void ClickViewMarkets()
        {
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]")))
                .SelectByText("View Markets");
            Thread.Sleep(2000);
        }

        public void SearchCPByBic(string searchTerm)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_BICCodeNameSearch")).SendKeys(searchTerm);
            Util.WaitForElementVisibleByXPath("//ul[contains(@class,'ui-autocomplete')]", 5);
            Browser.Browser.ClickByXPath("//ul[contains(@class,'ui-autocomplete')]");
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void VerifyCounterPartyIsNotFound()
        {
            SearchCP(Test.extRef);
            if(!Util.IsElementPresent(By.XPath("//td[contains(@class,'dataTables_empty')]")))
            {
                Assert.Fail("Counter Party was found");
            }
        }

        public PO_CounterParty_ViewCP ViewDetails(string cp)
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//a[text()='Create']", 10); 
            SearchCP(cp);
            ClickDetails();
            return new PO_CounterParty_ViewCP();
        }

        private void ClickDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }

        public PO_CounterParty_EditCP EditCounterParty(string counterParty)
        {
            SearchCP(counterParty);
            ClickEditCP();
            return new PO_CounterParty_EditCP();
        }
    }
}
