using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_TradeRepositories_CreateTradeRepositoriesPopUp
    {
        public PO_TradeRepositories_CreateTradeRepositoriesPopUp()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + TradeRepositoriesFieldIDs.TradeRepository_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(TradeRepositoriesFieldIDs.TradeRepository_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Browser.Browser.Instance.FindElement(By.Id(TradeRepositoriesFieldIDs.DeadLineCutOff)).SendKeys("14/10/2015");
        //    Browser.Browser.Instance.FindElement(By.Id(TradeRepositoriesFieldIDs.TradeRepository_BICCodeName)).SendKeys("14/10/2015");
            
        //    new SelectElement(Browser.Browser.Instance.FindElement(By.Id(TradeRepositoriesFieldIDs.TradeRepository_Address))).SelectByText("DTCC");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(TradeRepositoriesFieldIDs.TradeRepository_DeadLineTimeZone))).SelectByText("Fiji Standard Time");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(TradeRepositoriesFieldIDs.TradeRepository_Active))).SelectByText("Yes");
            Thread.Sleep(2000);
        }

        public PO_TradeRepositories_CreateTradeRepositoriesPopUp SetItem_Name(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(TradeRepositoriesFieldIDs.TradeRepository_Name))).SelectByText(value);
            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
