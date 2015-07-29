using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ResponseSettings_CreateResponseSettingsPopUp
    {
        public PO_ResponseSettings_CreateResponseSettingsPopUp()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + ResponseSettingsFieldIDs.EMIRResponseSetting_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(ResponseSettingsFieldIDs.EMIRResponseSetting_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Thread.Sleep(2000);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ResponseSettingsFieldIDs.EMIRResponseSetting_EMIRChannelFileMask))).SelectByText("DTCC Collateral Response");
            Thread.Sleep(2000);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ResponseSettingsFieldIDs.EMIRResponseSetting_FTPChannelSetting))).SelectByText("DtccSend");
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id(ResponseSettingsFieldIDs.EMIRResponseSetting_TradeRepositoryName)).SendKeys("DTCC");
            Util.WaitForElementVisibleByXPath("//li[text()='DTCC']", 15);
            Browser.Browser.ClickByXPath("//li[text()='DTCC']");
            Thread.Sleep(2000);
        }

        public PO_ResponseSettings_CreateResponseSettingsPopUp SetItem_Name(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ResponseSettingsFieldIDs.EMIRResponseSetting_Name))).SelectByText(value);
            return this;
        }
        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
