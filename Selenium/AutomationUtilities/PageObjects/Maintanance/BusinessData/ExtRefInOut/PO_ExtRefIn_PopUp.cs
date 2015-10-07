using AutomationUtilities.PageObjects.ExtRefInOut;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ExtRefIn_PopUp
    {
        public PO_ExtRefIn_PopUp()
        {
            try
            {

                Util.WaitForElementPresentByXPath("//span[@class='ui-dialog-title'][text()='Ext Ref Ins']", 60);

            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");

            }
        }



        public PO_ExtRefIn_CreateRefIn ClickCreate()
        {
            Util.WaitForElementVisibleByXPath("//a[text()='Create']", 15);
            Thread.Sleep(1000);
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            return new PO_ExtRefIn_CreateRefIn();
        }

        public void VerifyExtRefInIsCreated()
        {
            Thread.Sleep(3000);
            Util.CheckIfTextPresented("has been created");
        }

        public PO_ExtRefIn_EditRefIn EditRefIn()
        {
            SearchForExtRefIn(Test.extRef);
            SelectEdit();
            return new PO_ExtRefIn_EditRefIn();
        }

        private void SelectEdit()
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]")))
                .SelectByText("Edit");
            Thread.Sleep(2000);
        }

        public void SearchForExtRefIn(string searchTerm)
        {
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(searchTerm);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);


        }

        public PO_ExtRefIn_PopUp SetTypeSelectField(String field, String value)
        {
            Util.WaitForElementVisibleByXPath("//select[@id='" + field + "']", 15);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(field))).SelectByText(value);
            Thread.Sleep(2000);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
            return this;
        }

        public void VerifyExtRefInIsEdited()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("has been edited");
        }

        public PO_ExtRefIn_ViewDetails ViewRefIn()
        {
            SearchForExtRefIn(Test.extRef);
            ClickDetails();
            return new PO_ExtRefIn_ViewDetails();
        }

        private void ClickDetails()
        {
            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//select[contains(@onchange,'submitMyAction')]", 10);
            new SelectElement(Browser.Browser.Instance.FindElement(By.XPath("//select[contains(@onchange,'submitMyAction')]"))).SelectByText("Detail");
            Thread.Sleep(2000);
        }

        public void SearchForExtRefIn_ByReference(string searchTerm)
        {
            Browser.Browser.Instance.FindElement(By.Id("Search_ReferenceSearch")).SendKeys(searchTerm);
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void SelectTodayDateAndSearch()
        {
            Browser.Browser.Instance.FindElement(By.Id("CreatedSearch")).SendKeys(DateTime.Now.ToString("dd/MM/yyyy"));
            Browser.Browser.ClickByID("Search");
            Thread.Sleep(2000);
        }

        public void ClosePopUp()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }
    }

}

