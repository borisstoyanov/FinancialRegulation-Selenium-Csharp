using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_FTPChannelSettings_CreateFTPChannelSettingsPopUp
    {
        public PO_FTPChannelSettings_CreateFTPChannelSettingsPopUp()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + FTPChannelSettingsFieldIDs.FTPChannelSetting_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_FTPHost)).SendKeys("207.45.41.162");
            Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_FTPPort)).SendKeys("22");
            Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_FTPUserName)).SendKeys("F7DGTL5W");
            Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_FTPPassword)).SendKeys("Ltim1407");
            Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_FTPHostPath)).SendKeys("//DTS4.DOWN.G0TL5/");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_UseClearCommandChannel))).SelectByText("No");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_SecurityProtocol))).SelectByText("Explicit");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_SFTP))).SelectByText("Yes");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_DeleteFileAfterDownload))).SelectByText("No");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_FTPRetries))).SelectByText("1");
//            Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_FileTransferPrefix)).SendKeys("");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_DisablePathNormalisation))).SelectByText("Yes");
//            Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_SshPrivateKey)).SendKeys("");
            Thread.Sleep(2000);
        }

        public PO_FTPChannelSettings_CreateFTPChannelSettingsPopUp SetItem_Name(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(FTPChannelSettingsFieldIDs.FTPChannelSetting_Name))).SelectByText(value);
            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
