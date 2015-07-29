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

namespace AutomationUtilities.PageObjects.ReferenceData.InitiatorAggressor
{
    public class PO_InitiatorAggressor_Create
    {
        public PO_InitiatorAggressor_Create()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//*[text()='Create']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }

            Util.WaitForElementVisibleByXPath("//input[@id='" + ReferenceDataFieldIDs.Item_Name + "']", 15);
            Test.extRef = "TA" + Util.GetRandomID();

            Browser.Browser.Instance.FindElement(By.Id(ReferenceDataFieldIDs.Item_Name)).SendKeys(Test.extRef);

            var fixedNameElement = Browser.Browser.Instance.FindElement(By.Id(ReferenceDataFieldIDs.Item_Fixed_Name));            
            fixedNameElement.Clear();
            fixedNameElement.SendKeys(Test.extRef);

            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ReferenceDataFieldIDs.Item_Active))).SelectByText("Yes");
        }

        public PO_InitiatorAggressor_Create SetItem_Active(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(ReferenceDataFieldIDs.Item_Active))).SelectByText(value);
            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
