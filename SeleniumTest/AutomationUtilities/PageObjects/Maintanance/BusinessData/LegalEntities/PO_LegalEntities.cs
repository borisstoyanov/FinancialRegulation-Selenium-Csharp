using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.LegalEntities
{
    public class PO_LegalEntities
    {
        public PO_LegalEntities()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h3[text()='Search']", 15);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
                Test.TearDown(true);
            }
        }

        public PO_LegalEntity_Create CreateLegalEntity(string bicCode)
        {
            ClickCreate();
            return new PO_LegalEntity_Create(bicCode);
        }

        private void ClickCreate()
        {
            Thread.Sleep(3000);
            Util.WaitForElementVisibleByXPath("//a[text()='Create']", 10);
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            Thread.Sleep(2000);
        }

        public void VerifyLegalEntityCreated()
        {
            Thread.Sleep(2000);
            Util.CheckIfOneOfTextsPresented("has been created", "has been requested");
        }

        public void Close()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        public PO_LegalEntity_Edit EditLegalEntities()
        {
            SearchForLegalEntity(Test.extRef);
            SelectEdit();
            return new PO_LegalEntity_Edit();
        }

        private void SelectEdit()
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]")))
                .SelectByText("Edit");
            Thread.Sleep(2000);
        }

        public void SearchForLegalEntity(string id)
        {
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(Test.extRef);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);


        }

        public void VerifyLegalEntityIsEdited()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("has been edited");
        }

        public PO_LegalEntity_Details ViewLegalEntityDetails()
        {
            SearchForLegalEntity(Test.extRef);
            ClickDetails();
            return new PO_LegalEntity_Details();
        }

        private void ClickDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }

        public void SearchForLegalEntityByCompanyCode(string searchTerm)
        {
            Browser.Browser.Instance.FindElement(By.Id("Search_CompanyCodeSearch")).Clear();
            Browser.Browser.Instance.FindElement(By.Id("Search_CompanyCodeSearch")).SendKeys(Test.extRef);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }
    }
}
