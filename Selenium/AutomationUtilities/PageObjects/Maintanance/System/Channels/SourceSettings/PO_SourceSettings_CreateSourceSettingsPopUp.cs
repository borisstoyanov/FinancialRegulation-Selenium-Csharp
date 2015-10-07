using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_SourceSettings_CreateSourceSettingsPopUp
    {
        public PO_SourceSettings_CreateSourceSettingsPopUp()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + SourceSettingsFieldIDs.EMIRSourceSetting_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(SourceSettingsFieldIDs.EMIRSourceSetting_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id(SourceSettingsFieldIDs.EMIRSourceSetting_LegalEntityName)).SendKeys("State Street Bank GMBH London" + Keys.ArrowDown + Keys.Return);
            Thread.Sleep(2000);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(SourceSettingsFieldIDs.EMIRSourceSetting_ImportType1))).SelectByText("Trade");
            Thread.Sleep(2000);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(SourceSettingsFieldIDs.EMIRSourceSetting_EMIRSourceTransform1))).SelectByText("SSGXTremirTradeSSGXClient");
            Thread.Sleep(400);
            Browser.Browser.Instance.FindElement(By.Id(SourceSettingsFieldIDs.EMIRSourceSetting_SourceSystemName)).SendKeys("SSGX" + Keys.Down + Keys.Return);
            Thread.Sleep(2000);
            
        }

        public PO_SourceSettings_CreateSourceSettingsPopUp SetItem_ImportType1(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(SourceSettingsFieldIDs.EMIRSourceSetting_ImportType1))).SelectByText(value);
            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
