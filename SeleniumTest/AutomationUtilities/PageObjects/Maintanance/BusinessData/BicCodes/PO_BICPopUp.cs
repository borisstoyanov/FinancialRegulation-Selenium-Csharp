using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.BicPO
{
    public class PO_BICPopUp
    {
        public PO_BICPopUp()
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
        public PO_BIC_CreateBIC CreateNewBicCode()
        {
            ClickCreate();
            return new PO_BIC_CreateBIC();
        }
        private void ClickCreate()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//a[text()='Create']", 10);
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            
            Thread.Sleep(2000);
        }

        public void Close()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        public void VerifyBicCodeCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been created", "has been requested");
        }

        public PO_BIC_EditBIC EditBicCode()
        {
            SearchBicCodeByName(Test.extRef);
            ClickEdit();
            return new PO_BIC_EditBIC();
        }

        public void VerifyBicCodeEdited()
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

        public void SearchBicCodeByName(string addressName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(addressName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public PO_BIC_Details ViewBicCodeDetails()
        {
            SearchBicCodeByName(Test.extRef);
            ClickDetails();
            return new PO_BIC_Details();
        }

        private void ClickDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }

        public void SearchBicCodeByBicCode(string searchTerm)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_BICSearch")).SendKeys(searchTerm);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }
    }
}
