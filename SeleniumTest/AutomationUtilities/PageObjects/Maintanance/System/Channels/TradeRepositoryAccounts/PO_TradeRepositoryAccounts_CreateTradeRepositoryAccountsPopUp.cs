using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_TradeRepositoryAccounts_CreateTradeRepositoryAccountsPopUp
    {
        public PO_TradeRepositoryAccounts_CreateTradeRepositoryAccountsPopUp()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + TradeRepositoryAccountsFieldIDs.TradeRepositoryAccount_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(TradeRepositoryAccountsFieldIDs.TradeRepositoryAccount_TradeRepositoryName))
                .SendKeys("DTCC");
            Util.WaitForElementVisibleByXPath("//li[text()='DTCC']", 5);
            Browser.Browser.ClickByXPath("//li[text()='DTCC']");
            Browser.Browser.Instance.FindElement(By.Id(TradeRepositoryAccountsFieldIDs.TradeRepositoryAccount_ReportingEntityName))
                .SendKeys("Impendium");
            Util.WaitForElementVisibleByXPath("//li[text()='Impendium']", 5);
            Browser.Browser.ClickByXPath("//li[text()='Impendium']");
            Browser.Browser.Instance.FindElement(By.Id(TradeRepositoryAccountsFieldIDs.TradeRepositoryAccount_DelegatedReportingEntityName))
                .SendKeys("TEI_ENERGY_SPA - ");
            Util.WaitForElementVisibleByXPath("//li[text()='TEI_ENERGY_SPA - ']", 5);
            Browser.Browser.ClickByXPath("//li[text()='TEI_ENERGY_SPA - ']");
            Browser.Browser.Instance.FindElement(By.Id(TradeRepositoryAccountsFieldIDs.TradeRepositoryAccount_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
        }

        public PO_TradeRepositoryAccounts_CreateTradeRepositoryAccountsPopUp SetItem_Name(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(TradeRepositoryAccountsFieldIDs.TradeRepositoryAccount_Name))).SelectByText(value);
            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
