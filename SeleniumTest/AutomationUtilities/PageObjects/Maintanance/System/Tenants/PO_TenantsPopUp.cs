using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_TenantsPopUp
    {
        public PO_TenantsPopUp()
        {
            try
            {
                Util.WaitForElementVisibleByXPath("//a[text()='Create']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public void Close()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        public string GetTenantsCountMsg()
        {
            Thread.Sleep(2000);
            return Browser.Browser.Instance.FindElement(By.ClassName("dataTables_info")).Text;
        }

        public PO_Tenants_CreateTenantPopUp CreateNewTenant()
        {
            ClickCreate();
            return new PO_Tenants_CreateTenantPopUp();
        }

        private void ClickCreate()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//a[text()='Create']", 10);
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            Thread.Sleep(2000);
        }

        public void VerifyTenantCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been created", "has been requested");
        }

        public PO_Tenants_Edit EditTenant()
        {
            ClickEdit();
            return new PO_Tenants_Edit();
        }

        public void VerifyTenantEdited()
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

        public void SearchTenants(string referenceDataName)
        {
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(referenceDataName);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public PO_Tenants_Details ViewTenantDetails()
        {
            ClickDetails();
            return new PO_Tenants_Details();
        }

        private void ClickDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }

        public PO_Tenants_ViewUsers ViewTenantUsers()
        {
            ClickViewUsers();
            return new PO_Tenants_ViewUsers();
        }

        private void ClickViewUsers()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("View Users");
            Thread.Sleep(2000);
        }

        public PO_Tenants_EditUsers EditTenantUsers()
        {
            ClickEditUsers();
            return new PO_Tenants_EditUsers();
        }

        private void ClickEditUsers()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Edit Users");
            Thread.Sleep(2000);
        }

        public void CheckDelegationFlags()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//td[text()='0']//..//select"))).SelectByText("View Delegated Reporting Counterparties");
            Thread.Sleep(2000);
        }
    }
}
