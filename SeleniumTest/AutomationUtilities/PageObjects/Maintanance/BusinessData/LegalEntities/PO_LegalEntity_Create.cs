using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
namespace AutomationUtilities.PageObjects.LegalEntities
{
    public class PO_LegalEntity_Create : LegalEntityFields
    {
        public PO_LegalEntity_Create(string bicCode)
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
            
            Browser.Browser.Instance.FindElement(By.Id(LegalEntity_Name))
                .SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Browser.Browser.Instance.FindElement(By.Id(LegalEntity_BICCodeName))
                  .SendKeys(bicCode);
            Thread.Sleep(1000);
            Browser.Browser.Instance.FindElement(By.XPath("//li[text()='" + bicCode + "']"))
                  .Click();
            Browser.Browser.Instance.FindElement(By.Id(LegalEntity_CompanyCode))
                 .SendKeys(Test.extRef);
            Browser.Browser.Instance.FindElement(By.Id(LegalEntity_EntityShortName))
                 .SendKeys(Test.extRef);
            Browser.Browser.Instance.FindElement(By.Id(LegalEntity_SWIFTCode))
                 .SendKeys(Test.extRef);
            Browser.Browser.Instance.FindElement(By.Id(LegalEntity_Disclaimer))
                .SendKeys(Keys.Return);

        }
        public PO_LegalEntity_Create SetField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field))
                 .SendKeys(value);
            return this;
        }

        public PO_LegalEntity_Create SelectField(String field, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(field)))
                .SelectByValue(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
