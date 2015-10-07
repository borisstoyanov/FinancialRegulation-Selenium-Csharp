using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_Tenants_CreateTenantPopUp
    {
        public PO_Tenants_CreateTenantPopUp()
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
            Browser.Browser.Instance.FindElement(By.Id(TenantFieldIDs.Tenant_TenantId)).SendKeys(Test.extRef = Util.GetRandomID());
            Browser.Browser.Instance.FindElement(By.Id(TenantFieldIDs.Tenant_Description)).SendKeys(Test.extRef = Util.GetRandomID());
        }

        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
