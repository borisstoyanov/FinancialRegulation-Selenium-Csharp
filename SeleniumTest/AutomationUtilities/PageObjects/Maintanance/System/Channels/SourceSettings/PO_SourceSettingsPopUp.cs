using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_SourceSettingsPopUp
    {
        public PO_SourceSettingsPopUp()
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

        public PO_SourceSettings_CreateSourceSettingsPopUp CreateNewSourceSetting()
        {
            ClickCreate();
            return new PO_SourceSettings_CreateSourceSettingsPopUp();
        }

        private void ClickCreate()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//a[text()='Create']", 10);
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            Thread.Sleep(2000);
        }

        public void VerifySourceSettingsCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been created", "has been requested");
        }

        public PO_SourceSettings_Edit EditSourceSettings()
        {
            SearchSourceSettings(Test.extRef);
            ClickEdit();
            return new PO_SourceSettings_Edit();
        }

        public void VerifySourceSettingsEdited()
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

        public void SearchSourceSettings(string sourceSettingsName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(sourceSettingsName);
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }

        public PO_SourceSettings_Details ViewSourceSettingsDetails()
        {
            SearchSourceSettings(Test.extRef);
            ClickDetails();
            return new PO_SourceSettings_Details(Test.extRef);
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
