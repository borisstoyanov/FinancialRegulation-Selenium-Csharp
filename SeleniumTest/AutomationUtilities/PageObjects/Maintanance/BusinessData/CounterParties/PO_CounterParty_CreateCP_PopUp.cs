using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_CounterParty_CreateCP_PopUp
    {
        public PO_CounterParty_CreateCP_PopUp()
        {

            try
            {

                Util.WaitForElementPresentByXPath("//h2[text()='Create ']", 15);

            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");

            }
            Util.WaitForElementVisibleByXPath("//input[@id='" + CounterPartyInputFields.Counterparty_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(CounterPartyInputFields.Counterparty_Name)).Clear();
            Browser.Browser.Instance.FindElement(By.Id(CounterPartyInputFields.Counterparty_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Browser.Browser.Instance.FindElement(By.Id(CounterPartyInputFields.Counterparty_LegalName)).Clear();
            Browser.Browser.Instance.FindElement(By.Id(CounterPartyInputFields.Counterparty_LegalName)).SendKeys(Test.extRef);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(CounterPartySelectFields.Counterparty_CounterpartyType))).SelectByText("Broker");
        }
        public PO_CounterParty_CreateCP_PopUp SetCounterPartyInputField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }

        public PO_CounterParty_CreateCP_PopUp SetBicCode(string bic)
        {
            bic = bic.Remove(bic.Length - 2);

            Browser.Browser.Instance.FindElement(By.Id(CounterPartyInputFields.Counterparty_BICCodeName)).SendKeys(bic);

            Util.WaitForElementVisibleByXPath("//ul[contains(@class,'ui-autocomplete')]", 5);

            Browser.Browser.ClickByXPath("//ul[contains(@class,'ui-autocomplete')]");
            return this;
        }

        public PO_CounterParty_CreateCP_PopUp SetCounterPartySelectField(String field, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(field))).SelectByText(value);
            return this;
        }
        public void Create()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
