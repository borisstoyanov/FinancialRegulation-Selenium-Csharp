using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_WorkQueueCategories_CreateWorkQueueCategoriesPopUp
    {
        public PO_WorkQueueCategories_CreateWorkQueueCategoriesPopUp()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + WorkQueueCategoriesFieldIDs.Item_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(WorkQueueCategoriesFieldIDs.Item_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(WorkQueueCategoriesFieldIDs.Item_Active))).SelectByText("Yes");
        }

        public PO_WorkQueueCategories_CreateWorkQueueCategoriesPopUp SetItem_Active(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(WorkQueueCategoriesFieldIDs.Item_Active))).SelectByText(value);
            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
