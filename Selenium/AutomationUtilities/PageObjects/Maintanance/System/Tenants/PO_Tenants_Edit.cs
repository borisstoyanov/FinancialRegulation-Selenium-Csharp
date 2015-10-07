using AutomationUtilities.Exceptions;
using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_Tenants_Edit
    {
        public PO_Tenants_Edit()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//input[@id='Save']", 60);
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public PO_Tenants_Edit SetTenantId(String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(TenantFieldIDs.Tenant_TenantId)).SendKeys(Test.extRef = value);
            return this;
        }

        public PO_Tenants_Edit SetTenantDescripton(String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(TenantFieldIDs.Tenant_Description)).SendKeys(Test.extRef = Util.GetRandomID());
            return this;
        }

        public void Save()
        {
            Thread.Sleep(2000);
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
