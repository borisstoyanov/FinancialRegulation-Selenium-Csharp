using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationUtilities.PageObjects.Maintanance.BusinessData.EicCodes
{
    public class PO_EIC_CreateEIC
    {
        public PO_EIC_CreateEIC()
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
        }

        public PO_EIC_CreateEIC CreateEIC(string eicCodeType)
        {
            Thread.Sleep(4000);
            Util.WaitForElementVisibleByXPath("//input[@id='" + EicFieldIDs.EICCode_EIC + "']", 15);

            Browser.Browser.Instance.FindElement(By.Id(EicFieldIDs.EICCode_EIC)).SendKeys(Test.extRef = "TA" + Util.GetRandomID() + Util.GetRandomID() + "TATA");
            Browser.Browser.Instance.FindElement(By.Id(EicFieldIDs.EICCode_LongName)).SendKeys(Test.extRef);
            Browser.Browser.Instance.FindElement(By.Id(EicFieldIDs.EICCode_ShortName)).SendKeys(Test.extRef);
            SelectEicCodeType(eicCodeType);

            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }

        private void SelectEicCodeType(string eicCodeType)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(EicFieldIDs.EICCode_EICCodeTypeID))).SelectByText(eicCodeType);
        }
    }
}
