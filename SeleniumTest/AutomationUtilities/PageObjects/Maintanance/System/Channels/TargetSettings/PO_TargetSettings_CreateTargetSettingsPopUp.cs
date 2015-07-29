using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_TargetSettings_CreateTargetSettingsPopUp
    {
        public PO_TargetSettings_CreateTargetSettingsPopUp()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + TargetSettingsFieldIDs.EMIRTargetSetting_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(TargetSettingsFieldIDs.EMIRTargetSetting_ClientCode)).SendKeys("TA");
            Browser.Browser.Instance.FindElement(By.Id(TargetSettingsFieldIDs.EMIRTargetSetting_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(TargetSettingsFieldIDs.EMIRTargetSetting_TradeRepositoryAccount))).SelectByText("DTCC");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(TargetSettingsFieldIDs.EMIRTargetSetting_Tenant))).SelectByText("Global");
            Thread.Sleep(2000);
        }

        public PO_TargetSettings_CreateTargetSettingsPopUp SetItem_Name(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(TargetSettingsFieldIDs.EMIRTargetSetting_Name))).SelectByText(value);
            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
