using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ChannelFileMasks_CreateChannelFileMasksPopUp
    {
        public PO_ChannelFileMasks_CreateChannelFileMasksPopUp()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + ChannelFileMasksFieldIDs.Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(ChannelFileMasksFieldIDs.Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Browser.Browser.Instance.FindElement(By.Id(ChannelFileMasksFieldIDs.FilePrefix)).SendKeys("report*");
            Browser.Browser.Instance.FindElement(By.Id(ChannelFileMasksFieldIDs.FileSuffix)).SendKeys("*.xml");
            SelectTenant("Global");
            Thread.Sleep(2000);
        }

        public PO_ChannelFileMasks_CreateChannelFileMasksPopUp SelectTenant(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ChannelFileMasksFieldIDs.Tenant))).SelectByText(value);
            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
