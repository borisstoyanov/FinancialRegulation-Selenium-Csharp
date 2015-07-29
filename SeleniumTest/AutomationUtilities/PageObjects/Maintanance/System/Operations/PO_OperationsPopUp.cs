using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_OperationsPopUp
    {
        public PO_OperationsPopUp()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//a[text()='Operations']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public void CreateNewOperation()
        {
            ClickCreate();
        }

        public string GetOperationsCountMsg()
        {
            Thread.Sleep(2000);
            return Browser.Browser.Instance.FindElement(By.ClassName("dataTables_info")).Text;
        }

        public void Close()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        private void ClickCreate()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//a[text()='Create Operations From Controllers']", 10);
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create Operations From Controllers']");
            Thread.Sleep(2000);
        }

        public void VerifyOperationCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("Operations have been created");
        }

        public PO_Tenants_Edit EditOperation()
        {
            ClickEdit();
            return new PO_Tenants_Edit();
        }

        public void VerifyOperationsEdited()
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

        public void SearchOperations(string referenceDataName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(referenceDataName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public PO_Operations_Details ViewOperationDetails()
        {
            ClickDetails();
            return new PO_Operations_Details();
        }

        private void ClickDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }

        public PO_Operations_ViewRoles ViewOperationRoles()
        {
            ClickViewRoles();
            return new PO_Operations_ViewRoles();
        }

        private void ClickViewRoles()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("View Roles");
            Thread.Sleep(2000);
        }

        public PO_Operations_EditRoles EditOperationRoles()
        {
            ClickEditRoles();
            return new PO_Operations_EditRoles();
        }

        private void ClickEditRoles()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Edit Roles");
            Thread.Sleep(2000);
        }
    }
}
