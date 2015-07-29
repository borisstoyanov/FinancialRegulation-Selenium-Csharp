using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ChannelFileMasksPopUp
    {
        public PO_ChannelFileMasksPopUp()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h3[text()='Search']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public PO_ChannelFileMasks_CreateChannelFileMasksPopUp CreateNewChannelFileMasks()
        {
            ClickCreate();
            return new PO_ChannelFileMasks_CreateChannelFileMasksPopUp();
        }

        public void Close()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        private void ClickCreate()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//a[text()='Create']", 10);
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            Thread.Sleep(2000);
        }

        public void VerifyChannelFileMasksCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been created", "has been requested");
        }

        public PO_ChannelFileMasks_Edit EditChannelFileMasks()
        {
            SearchChannelFileMasks(Test.extRef);
            ClickEdit();
            return new PO_ChannelFileMasks_Edit();
        }

        public void VerifyChannelFileMasksEdited()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been edited", "has been requested");
        }

        private void ClickEdit()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Edit");
            Thread.Sleep(2000);
        }

        public void SearchChannelFileMasks(string channelFileMasksName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("NameSearch")).SendKeys(channelFileMasksName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public PO_ChannelFileMasks_Details ViewChannelFileMasksDetails()
        {
            SearchChannelFileMasks(Test.extRef);
            ClickDetails();
            return new PO_ChannelFileMasks_Details(Test.extRef);
        }

        private void ClickDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }
    }
}
