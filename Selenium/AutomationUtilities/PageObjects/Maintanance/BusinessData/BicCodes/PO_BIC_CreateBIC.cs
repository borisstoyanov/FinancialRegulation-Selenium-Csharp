using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.BicPO
{
    public class PO_BIC_CreateBIC
    {
        public PO_BIC_CreateBIC()
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
            Util.WaitForElementVisibleByXPath("//input[@id='" + BicFieldIDs.BICCode_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(BicFieldIDs.BICCode_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Browser.Browser.Instance.FindElement(By.Id(BicFieldIDs.BICCode_BIC)).SendKeys(Test.extRef);
            Browser.Browser.Instance.FindElement(By.Id(BicFieldIDs.BICCode_Branch)).SendKeys("1");
            Browser.Browser.Instance.FindElement(By.Id(BicFieldIDs.BICCode_Institution)).SendKeys(Test.extRef);
            Browser.Browser.Instance.FindElement(By.Id(BicFieldIDs.BICCode_CityHeading)).SendKeys(Test.extRef);
            Browser.Browser.Instance.FindElement(By.Id(BicFieldIDs.ValidFrom)).SendKeys("01/11/2014");
            Browser.Browser.Instance.FindElement(By.Id(BicFieldIDs.ValidTo)).SendKeys("01/11/2020");

        }
        public PO_BIC_CreateBIC SetBicCodeInputField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }

        public void Create()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
